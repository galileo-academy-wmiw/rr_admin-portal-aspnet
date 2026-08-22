// TODO: Move OrderDetails methods to OrderDetailsRepository after EF Core migration.

using Microsoft.EntityFrameworkCore;

namespace AdminPortal.Data.Repositories;

public class OrderRepository : IOrderRepository
{
    public readonly AppDbContext _context;
    

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    /*
    ==================================================================================================
    METHOD: Retrieves full Order objects.
    ==================================================================================================
    */
    public List<Order> GetAllSubmittedOrders()
    {
        List<Order> allSubmittedOrders =  _context.Orders.Include(o => o.Customer)
                                                         .ThenInclude(c => c.User)
                                                         .Where(o => o.OrderStatus == "SUBMITTED")
                                                         .OrderBy(o => o.OrderId)
                                                         .ToList();
        return allSubmittedOrders;
    }

    /*
    ==================================================================================================
    METHOD: Retrieve CART order for a specific customer.
    Cart is an Order object where Order.Status = CART.
    Returns null if no CART exists.
    ==================================================================================================
    */

    public Order? GetCartByCustomerId(int customerId)
    {
        Order? cartbyCustomerId =_context.Orders
                              .Include(o => o.Customer)
                              .ThenInclude(c => c.User)
                              .FirstOrDefault(o => o.CustomerId == customerId && o.OrderStatus == "CART");
        return cartbyCustomerId;
    }

    /*
    ==================================================================================================
    METHOD: Create new (empty) CART for customer by customer id, 
    A new Cart is a new row into 'orders' table whith status = CART.
    ==================================================================================================
    */
    public int CreateCart(int customerId)
    {
        Order newCart = new Order(customerId, "CART");
        
        _context.Orders.Add(newCart);
        int effectedEntries = _context.SaveChanges();
        return effectedEntries;
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
        if (orderDetail ==null)
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

    public List<OrderDetails> GetOrderDetailsByOrderId(int orderId)
    {
        List<OrderDetails> orderDetails = _context.OrderDetails
                                                               .Where(od => od.OrderId == orderId)
                                                               .OrderBy(od => od.DetailId)
                                                               .ToList();

        return orderDetails;
    }

    /*
    ==================================================================================================
    METHOD: Update the status of an order ( CART -> PLACED or PLACED -> REJECTED).
    And set order_date to today's date when placing order.
    Returns: (int) Affected rows.
    ==================================================================================================
    */

    public int UpdateOrderStatusByOrderId(int orderId, string newStatus)
    {
        Order? order = _context.Orders.FirstOrDefault(o => o.OrderId == orderId);
        if (order == null)
        {
            return 0;
        }
        DateTime dateTimeNow = DateTime.Now;
        
        order.UpdateStatus(newStatus, dateTimeNow);

        int effectedEntries = _context.SaveChanges();
        return effectedEntries;
    }
}