namespace WebApplication2;

public class FullProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public List<string> ImageUrl { get; set; } = new List<string>();
    public DateTime DataTime { get; set; }
}