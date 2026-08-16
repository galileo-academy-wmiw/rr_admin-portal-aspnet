using Microsoft.EntityFrameworkCore;
namespace AdminPortal.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().ToTable("product_catalogue");
        modelBuilder.Entity<Product>().Property(p => p.ProductId).HasColumnName("product_id");
        modelBuilder.Entity<Product>().Property(p => p.ProductName).HasColumnName("product_name");
        modelBuilder.Entity<Product>().Property(p => p.Description).HasColumnName("description");
        modelBuilder.Entity<Product>().Property(p => p.ProductPrice).HasColumnName("product_price");
        modelBuilder.Entity<Product>().Property(p => p.QuantityInStock).HasColumnName("quantity_in_stock");
    }
}