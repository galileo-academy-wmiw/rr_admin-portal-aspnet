using Microsoft.EntityFrameworkCore;
namespace AdminPortal.Data.Repositories;

public class OrderDetailsRepository: IOrderDetailsRepository
{
    private readonly AppDbContext _context;

    public OrderDetailsRepository(AppDbContext context)
    {
        _context = context;
    }

    // ------------------------------------------------------------
    // Get all order details (with Order + Product data)
    // ------------------------------------------------------------
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

}