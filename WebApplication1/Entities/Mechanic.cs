using System.ComponentModel.DataAnnotations;

namespace WinApplication;

public class Mechanic
{
    [Key]
    public int MechanicId { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    [MaxLength(14)]
    public string LicenceNumber { get; set; }

    public ICollection<Visit> Visits { get; set; } = new List<Visit>();
}

