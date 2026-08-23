namespace AdminPortal.Services;

public class AdminService : IAdminService
{
    private readonly IOrderRepository _orderRepository;

    public AdminService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public List<Order> GetAllPlacedOrders()
    {
        return _orderRepository.GetAllPlacedOrders();
    }
}
