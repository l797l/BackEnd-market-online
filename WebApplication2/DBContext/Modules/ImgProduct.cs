using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DBContext.Modules;

public class ImgProdect
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string  LinkImg { get; set; }
    public int ProdectId { get; set; }
    public Product Product { get; set; }
    
}