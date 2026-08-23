using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AdminPortal.Pages.Test_Pages;

public class TestPage : PageModel
{
    private readonly AppDbContext _context;

    public List<User> Users { get; set; } = [];
    public List<Customer> Customers { get; set; } = [];
    public List<Admin> Admins { get; set; } = [];
    public List<Product> Products { get; set; } = [];
    public List<Order> Orders { get; set; } = [];
    public List<OrderDetails> OrderDetails { get; set; } = [];

    public TestPage(AppDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        Users = _context.Users
            .OrderBy(u => u.UserId)
            .ToList();

        Customers = _context.Customers
            .Include(c => c.User)
            .OrderBy(c => c.CustomerId)
            .ToList();

        Admins = _context.Admins
            .Include(a => a.User)
            .OrderBy(a => a.AdminId)
            .ToList();

        Products = _context.Products
            .OrderBy(p => p.ProductId)
            .ToList();

        Orders = _context.Orders
            .Include(o => o.Customer)
            .ThenInclude(c => c.User)
            .OrderBy(o => o.OrderId)
            .ToList();

        OrderDetails = _context.OrderDetails
            .Include(od => od.Order)
            .Include(od => od.Product)
            .OrderBy(od => od.DetailId)
            .ToList();
    }
}