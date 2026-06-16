
using Microsoft.EntityFrameworkCore;
using WebApplication2.DBContext.Modules;

public class AppDBContext: DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options): base(options) {}
    public DbSet<Users>  Users { get; set; }
    public DbSet<Product>  Product{ get; set; }
    public DbSet<Orders>  Orders { get; set; }
    public DbSet<OrderProduct> OrderProduct { get; set; }
    public DbSet<ImgProduct>ImgProduct { get; set; }
    
}
