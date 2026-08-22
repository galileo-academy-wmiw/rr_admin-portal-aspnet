namespace AdminPortal.Data.Repositories.Interfaces;

public interface IOrderRepository
{
    List<Order> GetAllSubmittedOrders();
    Order? GetCartByCustomerId(int customerId);
    int CreateCart(int customerId);
    int UpdateOrderStatusByOrderId(int orderId, string newStatus);
}