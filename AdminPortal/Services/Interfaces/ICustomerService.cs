namespace AdminPortal.Services.Interfaces;
public interface ICustomerService
{
    List<Customer> GetAllCustomers();
    Customer? GetCustomerById(int customerId);
    int? GetCustomerIdByUserName(string username);
    Order GetOrCreateCart(int customerId);
    bool AddProductToCart(int customerId, int productId, int quantity);
    bool RemoveProductFromCart(int customerId, int productId, int quantityToRemove);

    // View cart items.
    List<OrderDetails> GetCartItems(int customerId);
     // Place order: converts CART -> PLACED and creates a fresh empty CART
    bool PlaceOrder(int customerId);
}
