using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinApplication;

public class Service
{
    [Key]
    public int ServiceId { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal BaseFee { get; set; }

    public ICollection<VisitService> VisitServices { get; set; } = new List<VisitService>();
}

