using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace WebApplication2.DBContext.Modules;

public class Orders
{
    [Required][Key]
    public int Id { get; set; }
    [Required]
    public Users Users { get; set; }
    public int UserId { get; set; }
    [Required] public bool StatusPay { get; set; } = false;
    [Required] public DateTime Date { get; set; } = DateTime.Now;
    [Required]
    public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();


}