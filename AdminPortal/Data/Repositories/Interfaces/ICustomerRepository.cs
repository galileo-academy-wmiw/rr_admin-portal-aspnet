namespace AdminPortal.Data.Repositories.Interfaces;
public interface ICustomerRepository
{
    List<Customer> GetAllCustomers();
    Customer? GetCustomerById(int customerId);
}
