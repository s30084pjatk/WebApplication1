using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinApplication;

public class VisitService
{
    
    public int VisitId { get; set; }

    [ForeignKey(nameof(VisitId))]
    public Visit Visit { get; set; }

    [Required]
    public int ServiceId { get; set; }

    [ForeignKey(nameof(ServiceId))]
    public Service Service { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal ServiceFee { get; set; }
}

