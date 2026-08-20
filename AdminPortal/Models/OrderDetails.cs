using System.ComponentModel.DataAnnotations;

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

        public OrderDetails(int orderId, int productId, int amount, double totalPrice)
    {
        OrderId = orderId;
        ProductId = productId;
        Amount = amount;
        TotalPrice = totalPrice;
    }

    public void UpdateAmountAndTotal(int amount, double totalPrice)
    {
        Amount = amount;
        TotalPrice = totalPrice;
    }

}