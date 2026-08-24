using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPortal.Pages.Orders;
public class IndexModel : PageModel
{
    private readonly IOrderService _orderService;
    public List<Order> Orders {get; private set;} = [];
    public IndexModel(IOrderService orderService)
    {
        _orderService = orderService;
    }
    public void OnGet()
    {
        Orders = _orderService.GetAllPlacedOrders();
    }
}