using System.ComponentModel.DataAnnotations;

namespace AdminPortal.Models;

public class Order
{
    [Key]
    public int OrderId { get; private set; }
    public int CustomerId { get; private set; }
    public Customer Customer { get; private set; } = null!; // Navigation property
    public DateTime OrderDate { get; private set; }
    public string OrderStatus { get; private set; }
    public Order(int orderId, Customer customer, DateTime orderDate, string orderStatus)
    {
        OrderId = orderId;
        Customer = customer;
        OrderDate = orderDate;
        OrderStatus = orderStatus;
    }

    public Order(int customerId, string orderStatus)
    {
        CustomerId = customerId;
        OrderDate = DateTime.Now;
        OrderStatus = orderStatus;
    }

    public void UpdateStatus (string orderStatus, DateTime orderDate)
    {
        OrderStatus = orderStatus;
        OrderDate = orderDate;
    }
}
