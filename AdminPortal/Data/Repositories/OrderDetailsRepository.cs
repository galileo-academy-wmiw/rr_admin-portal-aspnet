using Microsoft.EntityFrameworkCore;
namespace AdminPortal.Data.Repositories;

public class OrderDetailsRepository : IOrderDetailsRepository
{
    private readonly AppDbContext _context;

    public OrderDetailsRepository(AppDbContext context)
    {
        _context = context;
    }

    /*
    ==================================================================================================
    METHOD: Get all order details (with Order + Product data)
    ==================================================================================================
    */

    public List<OrderDetails> GetAllOrderDetails()
    {

        List<OrderDetails> orderDetails = _context.OrderDetails
                                                               .Include(od => od.Order)
                                                               .ThenInclude(o => o.Customer)
                                                               .Include(od => od.Product)
                                                               .OrderBy(od => od.DetailId)
                                                               .ToList();
        return orderDetails;
    }

    /*
    ==================================================================================================
    METHOD: Check if product already exists in CART
    - Returns Null if nor Cart is found.
    - Returns Orderdetails object if a CART is found.
    ==================================================================================================
    */
    public OrderDetails? GetOrderDetailByOrderIdAndProductId(int orderId, int productId)
    {
        OrderDetails? orderDetail = _context.OrderDetails
                                    .FirstOrDefault(od => od.OrderId == orderId && od.ProductId == productId);
        return orderDetail;
    }

    /*
    ==================================================================================================
    METHOD: Insert new product into order_details
    ==================================================================================================
    */
    public bool InsertOrderDetail(int orderId, int productId, int amount, double totalPrice)
    {
        var newOrderDetail = new OrderDetails(orderId, productId, amount, totalPrice);
        _context.OrderDetails.Add(newOrderDetail);

        int effectedEntries = _context.SaveChanges();
        return effectedEntries > 0;
    }

    /*
    ==================================================================================================
    METHOD: Update existing order_detail amount and total_price.
    ==================================================================================================
    */
    public bool UpdateOrderDetail(int detailId, int newAmount, double newTotalPrice)
    {
        OrderDetails? orderDetail = _context.OrderDetails.FirstOrDefault(od => od.DetailId == detailId);
        if (orderDetail == null)
            return false;

        orderDetail.UpdateAmountAndTotal(newAmount, newTotalPrice);

        int effectedEntries = _context.SaveChanges();
        return effectedEntries > 0;
    }

    /*
    ==================================================================================================
    METHOD: Delete an order_details row by detail_id.
    Used when cart line amount becomes 0.
    ==================================================================================================
    */
    public bool DeleteOrderDetailByDetailId(int detailId)
    {
        OrderDetails? orderDetail = _context.OrderDetails.FirstOrDefault(od => od.DetailId == detailId);

        if (orderDetail == null)
        {
            return false;
        }

        _context.OrderDetails.Remove(orderDetail);

        int effectedEntries = _context.SaveChanges();
        return effectedEntries > 0;
    }

    /*
    ==================================================================================================
    METHOD: Retrieve all order details for a specific order.
    ==================================================================================================
    */
    public List<OrderDetails> GetOrderDetailsByOrderId(int orderId)
    {
        List<OrderDetails> orderDetails = _context.OrderDetails
                                                               .Include(od => od.Product)
                                                               .Where(od => od.OrderId == orderId)
                                                               .OrderBy(od => od.DetailId)
                                                               .ToList();

        return orderDetails;
    }

}
