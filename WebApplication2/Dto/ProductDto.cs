using System.ComponentModel.DataAnnotations;

namespace WebApplication2;

public class ProductDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
    public string Description { get; set; }
    [Required]
    public List<IFormFile> Image { get; set; }
}