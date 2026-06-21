namespace WinApplication;

public interface IVisitsService
{
    Task<VisitGetDto> GetVisitByIdAsync(int visitId);
    Task<int> CreateVisitAsync(VisitPostDto dto);
}

