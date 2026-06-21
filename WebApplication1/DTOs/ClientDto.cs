using System.ComponentModel.DataAnnotations;

namespace WinApplication;

public class ClientDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }
}