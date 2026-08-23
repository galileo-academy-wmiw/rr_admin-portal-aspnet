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
    public List<Order> GetAllPlacedOrders()
    {
        List<Order> allPlacedOrders =  _context.Orders.Include(o => o.Customer)
                                                      .ThenInclude(c => c.User)
                                                      .Where(o => o.OrderStatus == "PLACED")
                                                      .OrderBy(o => o.OrderId)
                                                      .ToList();
        return allPlacedOrders;
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
