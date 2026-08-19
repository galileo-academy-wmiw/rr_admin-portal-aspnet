using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace AdminPortal.Models;

public class OrderDetails
{   [Key]
    public int DetailId { get; private set; }
    public int OrderId { get; private set; }
    public Order Order { get; private set; } = null!; // Navigation property
    public Product Product { get; private set; } = null!; // Navigation property
    public int ProductId { get; private set; }
    public int Amount { get; private set; }
    public double TotalPrice { get; private set; }

    public OrderDetails(int detailId, int orderId, int productId, int amount, double totalPrice)
    {
        DetailId = detailId;
        OrderId = orderId;
        ProductId = productId;
        Amount = amount;
        TotalPrice = totalPrice;
    }
}