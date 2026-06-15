using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DBContext.Modules;

public class User
{
    [Required] [Key]
    public int Id { get; set; }
    [Required][MinLength(3), MaxLength(50)]
    public string FullName { get; set; }
    [Required][MinLength(3)]
    public string Email { get; set; }
    [Required][MinLength(6)]
    public string Password { get; set; }

    public DateTime DateCreated { get; set; } = DateTime.Now;
    
    public List<Orders> Orders { get; set; }
}