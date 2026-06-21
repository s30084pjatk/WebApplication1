using System.ComponentModel.DataAnnotations;

namespace WinApplication;

public class Client
{
    [Key]
    public int ClientId { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ICollection<Visit> Visits { get; set; } = new List<Visit>();
}

