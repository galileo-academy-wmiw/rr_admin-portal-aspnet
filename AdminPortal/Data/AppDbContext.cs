using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
namespace AdminPortal.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Admin> Admins { get; set;}
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
    public DbSet<Order> Orders { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   
        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<User>().Property(u => u.UserId).HasColumnName("user_id");
        modelBuilder.Entity<User>().Property(u => u.FirstName).HasColumnName("first_name");
        modelBuilder.Entity<User>().Property(u => u.LastName).HasColumnName("last_name");
        modelBuilder.Entity<User>().Property(u => u.UserName).HasColumnName("user_name");
        modelBuilder.Entity<User>().Property(u => u.UserEmail).HasColumnName("user_email");
        modelBuilder.Entity<User>().Property(u => u.UserAddress).HasColumnName("user_address");

        modelBuilder.Entity<Customer>().ToTable("customer");
        modelBuilder.Entity<Customer>().Property(c => c.CustomerId).HasColumnName("customer_id");
        modelBuilder.Entity<Customer>().Property(c => c.UserId).HasColumnName("user_id");
        modelBuilder.Entity<Customer>().Property(c => c.Age).HasColumnName("age");
        modelBuilder.Entity<Customer>()
                                       .HasOne(c => c.User)
                                       .WithMany()
                                       .HasForeignKey(c => c.UserId);

        modelBuilder.Entity<Product>().ToTable("product_catalogue");
        modelBuilder.Entity<Product>().Property(p => p.ProductId).HasColumnName("product_id");
        modelBuilder.Entity<Product>().Property(p => p.ProductName).HasColumnName("product_name");
        modelBuilder.Entity<Product>().Property(p => p.Description).HasColumnName("description");
        modelBuilder.Entity<Product>().Property(p => p.ProductPrice).HasColumnName("product_price");
        modelBuilder.Entity<Product>().Property(p => p.QuantityInStock).HasColumnName("quantity_in_stock");

        modelBuilder.Entity<OrderDetails>().ToTable("order_details");
        modelBuilder.Entity<OrderDetails>().Property(od => od.DetailId).HasColumnName("detail_id");
        modelBuilder.Entity<OrderDetails>().Property(od => od.OrderId).HasColumnName("order_id");
        modelBuilder.Entity<OrderDetails>().Property(od => od.ProductId).HasColumnName("product_id");
        modelBuilder.Entity<OrderDetails>().Property(od => od.Amount).HasColumnName("amount");
        modelBuilder.Entity<OrderDetails>().Property(od => od.TotalPrice).HasColumnName("total_price");
        modelBuilder.Entity<OrderDetails>()
                                      .HasOne(od => od.Product)
                                      .WithMany()
                                      .HasForeignKey(od => od.ProductId);
        modelBuilder.Entity<OrderDetails>()
                                           .HasOne(od => od.Order)
                                           .WithMany()
                                           .HasForeignKey(od => od.OrderId);

        modelBuilder.Entity<Order>().ToTable("orders");
        modelBuilder.Entity<Order>().Property(o => o.OrderId).HasColumnName("order_id");
        modelBuilder.Entity<Order>().Property(o => o.CustomerId).HasColumnName("customer_id");
        modelBuilder.Entity<Order>().Property(o => o.OrderDate).HasColumnName("order_date");
        modelBuilder.Entity<Order>().Property(o => o.OrderStatus).HasColumnName("order_status");
        modelBuilder.Entity<Order>()
                                    .HasOne(o => o.Customer)
                                    .WithMany()
                                    .HasForeignKey(o => o.CustomerId);

    }
}