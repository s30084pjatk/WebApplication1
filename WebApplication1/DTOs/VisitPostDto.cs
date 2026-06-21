using System.ComponentModel.DataAnnotations;

namespace WinApplication;

public class VisitPostDto
{
    public int ClientId { get; set; }
    [MaxLength(14)]
    public string MechanicLicenceNumber { get; set; }
    [MinLength(1)]
    public List<VisitServicePostDto> Services { get; set; }
}

