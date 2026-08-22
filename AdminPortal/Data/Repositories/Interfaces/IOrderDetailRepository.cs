namespace AdminPortal.Data.Repositories.Interfaces;

public interface IOrderDetailsRepository
{
    List<OrderDetails> GetAllOrderDetails();
    OrderDetails? GetOrderDetailByOrderIdAndProductId(int orderId, int productId);
    bool InsertOrderDetail(int orderId, int productId, int amount, double totalPrice);
    bool UpdateOrderDetail(int detailId, int newAmount, double newTotalPrice);
    bool DeleteOrderDetailByDetailId(int detailId);
    List<OrderDetails> GetOrderDetailsByOrderId(int orderId);
}