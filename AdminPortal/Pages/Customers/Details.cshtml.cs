using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPortal.Pages.Customers;

public class DetailsModel : PageModel
{
    private readonly ICustomerService _customerService;

    public Customer Customer { get; private set; } = null!;

    public DetailsModel(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public IActionResult OnGet(int id)
    {
        Customer? customer = _customerService.GetCustomerById(id);

        if (customer == null)
        {
            return NotFound();
        }

        Customer = customer;
        return Page();
    }
}
