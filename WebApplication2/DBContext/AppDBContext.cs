
using Microsoft.EntityFrameworkCore;
using WebApplication2.DBContext.Modules;

public class AppDBContext: DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options): base(options) {}
    public DbSet<Users>  Users { get; set; }
    public DbSet<Product>  Products { get; set; }
    public DbSet<Orders>  Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<ImgProduct>ImgProducts { get; set; }
    
}
