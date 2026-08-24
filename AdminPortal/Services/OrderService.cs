namespace AdminPortal.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderDetailsRepository _orderDetailsRepository;

    public OrderService(IOrderRepository orderRepository, IOrderDetailsRepository orderDetailsRepository)
    {
        _orderRepository = orderRepository;
        _orderDetailsRepository = orderDetailsRepository;
    }

    public List<Order> GetAllPlacedOrders()
    {
        return _orderRepository.GetAllPlacedOrders();
    }

    public Order? GetPlacedOrderById(int orderId)
    {
        return _orderRepository.GetPlacedOrderById(orderId);
    }

    public List<OrderDetails> GetOrderDetailsByOrderId(int orderId)
    {
        return _orderDetailsRepository.GetOrderDetailsByOrderId(orderId);
    }

    public bool CompleteOrder(int orderId)
    {
        return UpdatePlacedOrderStatus(orderId, "COMPLETED");
    }

    public bool RejectOrder(int orderId)
    {
        return UpdatePlacedOrderStatus(orderId, "REJECTED");
    }

    private bool UpdatePlacedOrderStatus(int orderId, string newStatus)
    {
        Order? order = _orderRepository.GetPlacedOrderById(orderId);

        if (order == null)
        {
            return false;
        }

        int result = _orderRepository.UpdateOrderStatusByOrderId(orderId, newStatus);
        return result > 0;
    }
}
