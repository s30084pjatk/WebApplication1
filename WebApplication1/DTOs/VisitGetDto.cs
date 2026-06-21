namespace WinApplication;

public class VisitGetDto
{
    public DateTime Date { get; set; }
    public ClientDto Client { get; set; }
    public MechanicDto Mechanic { get; set; }
    public List<VisitServiceDto> VisitServices { get; set; }
}