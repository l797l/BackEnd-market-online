using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DBContext.Modules;

public class OrderProdect
{
    [Key][Required]
    int Id { get; set; }
    [Required]
    dynamic price  { get; set; }
    [Required]
    int ProductId { get; set; }
    [Required]
    int OrderId { get; set; }
    Orders Order { get; set; }
    Product Product { get; set; }
    
    
}