using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPortal.Pages.Orders;

[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
    private readonly IOrderService _orderService;
    public List<Order> Orders { get; private set; } = [];
    public IndexModel(IOrderService orderService)
    {
        _orderService = orderService;
    }
    public void OnGet()
    {
        Orders = _orderService.GetAllPlacedOrders();
    }

    public IActionResult OnPostComplete(int id)
    {
        bool completed = _orderService.CompleteOrder(id);

        if (!completed)
        {
            return NotFound();
        }

        return RedirectToPage("/Orders/Index");
    }

    public IActionResult OnPostReject(int id)
    {
        bool rejected = _orderService.RejectOrder(id);

        if (!rejected)
        {
            return NotFound();
        }

        return RedirectToPage("/Orders/Index");
    }
}
