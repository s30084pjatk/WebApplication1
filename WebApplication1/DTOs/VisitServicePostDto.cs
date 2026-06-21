using System.ComponentModel.DataAnnotations;

namespace WinApplication;

public class VisitServicePostDto
{

    [MaxLength(100)]
    public string ServiceName { get; set; }


    [Range(0, double.MaxValue)]
    public decimal ServiceFee { get; set; }
}

