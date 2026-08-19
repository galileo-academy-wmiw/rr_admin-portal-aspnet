using Microsoft.EntityFrameworkCore;

namespace AdminPortal.Data.Repositories;

public class AdminRepository: IAdminRepository
{
    private readonly AppDbContext _context;

    public AdminRepository(AppDbContext context)
    {
        _context = context;
    }

    // ------------------------------------------------------------------
    // METHOD: Retrieves full Admin objects.
    // ------------------------------------------------------------------

    public List<Admin> GetAllAdmins()
    {
        List<Admin> allAdmins = _context.Admins
                                               .Include(a => a.User) 
                                               .OrderBy(a => a.AdminId).ToList();
                                               
        return allAdmins;
    }
}