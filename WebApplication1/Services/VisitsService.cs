using Microsoft.EntityFrameworkCore;
using WinApplication;

namespace WinApplication1;

public class VisitsService : IVisitsService
{
    private readonly AppDbContext _context;

    public VisitsService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<VisitGetDto> GetVisitByIdAsync(int visitId)
    {
        var visit = await _context.Visits
            .Where(v => v.VisitId == visitId)
            .Select(v => new VisitGetDto
            {
                Date = v.Date,
                Client = new ClientDto
                {
                    FirstName = v.Client.FirstName,
                    LastName = v.Client.LastName,
                    DateOfBirth = v.Client.DateOfBirth
                },
                Mechanic = new MechanicDto
                {
                    MechanicId = v.Mechanic.MechanicId,
                    LicenceNumber = v.Mechanic.LicenceNumber
                },
                VisitServices = v.VisitServices.Select(vs => new VisitServiceDto
                {
                    Name = vs.Service.Name,
                    ServiceFee = vs.ServiceFee
                }).ToList()
            })
            .FirstOrDefaultAsync();

        return visit;
    }

    public async Task<int> CreateVisitAsync(VisitPostDto dto)
    {
        var clientExists = await _context.Clients
            .AnyAsync(c => c.ClientId == dto.ClientId);
        if (!clientExists)
        {
            throw new InvalidOperationException($"Client with id {dto.ClientId} not found");
        }

        var mechanic = await _context.Mechanics
            .FirstOrDefaultAsync(m => m.LicenceNumber == dto.MechanicLicenceNumber);
        if (mechanic == null)
        {
            throw new InvalidOperationException($"Mechanic with licence number {dto.MechanicLicenceNumber} not found");
        }

        var requestedNames = dto.Services.Select(s => s.ServiceName).Distinct().ToList();
        var foundServices = await _context.Services
            .Where(s => requestedNames.Contains(s.Name))
            .ToListAsync();

        if (foundServices.Count != requestedNames.Count)
        {
            throw new InvalidOperationException("One or more requested services do not exist");
        }

        await using var transaction = await _context.Database.BeginTransactionAsync();

        var visit = new Visit
        {
            ClientId = dto.ClientId,
            MechanicId = mechanic.MechanicId,
            Date = DateTime.UtcNow
        };

        await _context.Visits.AddAsync(visit);
        await _context.SaveChangesAsync();

        foreach (var serviceDto in dto.Services)
        {
            var matchedService = foundServices.First(s => s.Name == serviceDto.ServiceName);
            await _context.VisitServices.AddAsync(new VisitService
            {
                VisitId = visit.VisitId,
                ServiceId = matchedService.ServiceId,
                ServiceFee = serviceDto.ServiceFee
            });
        }

        await _context.SaveChangesAsync();
        await transaction.CommitAsync();

        return visit.VisitId;
    }
}