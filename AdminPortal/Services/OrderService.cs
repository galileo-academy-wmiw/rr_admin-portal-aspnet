namespace AdminPortal.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public List<Order> GetAllPlacedOrders()
    {
        return _orderRepository.GetAllPlacedOrders();
    }
}
