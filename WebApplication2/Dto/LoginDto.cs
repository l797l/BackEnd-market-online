using System.ComponentModel.DataAnnotations;

namespace WebApplication2;

public class LoginDto
{
    [Required][EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}