namespace AdminPortal.Services.Interfaces;

public interface IProductService
{
    List<Product> GetAllProducts();
    Product? GetProductById(int productId);
    bool AddProduct(string productName, string description, double productPrice, int quantityInStock);
    bool UpdateProduct(int productId, string productName, string description, double productPrice, int quantityInStock);
    bool DeleteProduct(int productId);
}
