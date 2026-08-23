namespace AdminPortal.Services;

public class ProductService: IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

        public bool AddProduct(string productName, string description, double productPrice, int quantityInStock)
    {
        int result = _productRepository.InsertProduct(productName, description, productPrice, quantityInStock);
        return result == 1;
    }

    public bool UpdateProduct(int productId, string productName, string description, double productPrice, int quantityInStock)
    {
        int result = _productRepository.UpdateProduct(productId, productName, description, productPrice, quantityInStock);
        return result > 0;
    }

    public bool DeleteProduct(int productId)
    {
        if (_productRepository.IsProductInUse(productId))
            return false;

        int result = _productRepository.DeleteProduct(productId);
        return result > 0;
    }

    public List<Product> GetAllProducts()
    {
        return _productRepository.GetAllProducts();
    }
}