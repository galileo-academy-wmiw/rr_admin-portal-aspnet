namespace AdminPortal.Data.Repositories.Interfaces;

public interface IOrderRepository
{
    List<Order> GetAllPlacedOrders();
    Order? GetPlacedOrderById(int orderId);
    Order? GetCartByCustomerId(int customerId);
    int CreateCart(int customerId);
    int UpdateOrderStatusByOrderId(int orderId, string newStatus);
}
