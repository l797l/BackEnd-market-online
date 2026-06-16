using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DBContext.Modules;

public class Users
{
    [Required] [Key]
    public int Id { get; set; }
    [Required][MinLength(3), MaxLength(50)]
    public string FullName { get; set; }
    [Required][MinLength(3)] [EmailAddress] 
    public string Email { get; set; }
    [Required][MinLength(6)]
    public string Password { get; set; }

    public DateTime DateTime { get; set; } = DateTime.Now;
    
    public List<Orders> Orders { get; set; }
}