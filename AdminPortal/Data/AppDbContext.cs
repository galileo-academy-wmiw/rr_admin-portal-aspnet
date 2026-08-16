using Microsoft.EntityFrameworkCore;
namespace AdminPortal.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
        
    }
}