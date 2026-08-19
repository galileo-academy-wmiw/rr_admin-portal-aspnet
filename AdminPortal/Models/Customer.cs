using System.ComponentModel.DataAnnotations;

namespace AdminPortal.Models;

public class Customer
{
    [Key]
    public int CustomerId { get; private set; }
    public int UserId { get; set; }
    public int Age { get; private set; }
    public User User { get; private set; } = null!; // Navigational property



    public Customer(
        int customerId,
        int userId,
        int age
        )
    {
        this.CustomerId = customerId;
        this.UserId = userId;
        this.Age = age;
    }

    public Customer(int customerId)
    {
        CustomerId = customerId;
    }

}