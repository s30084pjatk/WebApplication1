using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinApplication;

public class Visit
{
    [Key]
    public int VisitId { get; set; }
    [ForeignKey(nameof(ClientId))]
    public int ClientId { get; set; }
    public Client Client { get; set; }
    [ForeignKey(nameof(MechanicId))]
    public int MechanicId { get; set; }
    public Mechanic Mechanic { get; set; }
    public DateTime Date { get; set; }
    public ICollection<VisitService> VisitServices { get; set; } = new List<VisitService>();
}

