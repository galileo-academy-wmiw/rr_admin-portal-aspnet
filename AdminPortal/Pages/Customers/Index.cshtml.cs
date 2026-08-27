using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPortal.Pages.Customers;

[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
    private readonly ICustomerService _customerService;

    public List<Customer> Customers { get; private set; } = [];

    public IndexModel(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public void OnGet()
    {
        Customers = _customerService.GetAllCustomers();
    }
}
