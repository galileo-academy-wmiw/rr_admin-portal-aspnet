namespace AdminPortal.Services;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;

    public AdminService(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public List<Admin> GetAllAdmins()
    {
        return _adminRepository.GetAllAdmins();
    }
}
