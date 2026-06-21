using Microsoft.AspNetCore.Mvc;

namespace WinApplication;

[Route("api/visits")]
[ApiController]
public class VisitsController : ControllerBase
{
    private readonly IVisitsService _visitsService;

    public VisitsController(IVisitsService visitsService)
    {
        _visitsService = visitsService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVisit(int id)
    {
        var visit = await _visitsService.GetVisitByIdAsync(id);
        if (visit == null)
        {
            return NotFound($"Visit with id {id} not found");
        }

        return Ok(visit);
    }

    [HttpPost]
    public async Task<IActionResult> CreateVisit([FromBody] VisitPostDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var visitId = await _visitsService.CreateVisitAsync(dto);
            return CreatedAtAction(nameof(GetVisit), new { id = visitId }, new { VisitId = visitId });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

