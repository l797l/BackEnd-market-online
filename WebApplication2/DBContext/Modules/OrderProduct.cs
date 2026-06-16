using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DBContext.Modules;

public class OrderProduct
{
    [Key][Required]
    public  int Id { get; set; }
    [Required]
    public  decimal price  { get; set; }
    [Required]
    public  int ProductId { get; set; }
    [Required]
    public int OrderId { get; set; }
    public Orders Order { get; set; }
    public Product Product { get; set; }
    
    
}