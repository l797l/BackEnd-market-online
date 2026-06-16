using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DBContext.Modules;

public class ImgProduct
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string  LinkImg { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    
}