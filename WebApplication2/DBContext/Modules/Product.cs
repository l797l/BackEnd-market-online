using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DBContext.Modules;

public class Product
{
    [Required][Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
    public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    public List<ImgProduct> ImgProducts = new List<ImgProduct>();
}