using Microsoft.EntityFrameworkCore;

namespace AdminPortal.Data.Repositories;

public class CustomerRepository: ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;    
    }

    // Retrieves full Customer objects (Customer has User).
    public List<Customer> GetAllCustomers()
    {
        List<Customer> allCustomers = _context.Customers
                                                        .Include(c => c.User)
                                                        .OrderBy(c => c.CustomerId)
                                                        .ToList();

        return allCustomers;
    }

    public Customer? GetCustomerById(int customerId)
    {
        return _context.Customers
            .Include(c => c.User)
            .FirstOrDefault(c => c.CustomerId == customerId);
    }
}
