namespace AdminPortal.Services.Interfaces;

public interface IOrderService
{
    List<Order> GetAllPlacedOrders();
    Order? GetPlacedOrderById(int orderId);
    List<OrderDetails> GetOrderDetailsByOrderId(int orderId);
    bool CompleteOrder(int orderId);
    bool RejectOrder(int orderId);
}
