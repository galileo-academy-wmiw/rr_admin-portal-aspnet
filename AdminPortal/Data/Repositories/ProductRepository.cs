namespace AdminPortal.Data.Repositories;

public class ProductRepository: IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

/*
------------------------------------------------------------------
METHOD: Retrieves full Product objects.
------------------------------------------------------------------
*/
    public List<Product> GetAllProducts()
    {
        return _context.Products.OrderBy(p => p.ProductId).ToList();
    }

/*
------------------------------------------------------------------
METHOD: Retrieves a Product object by Product id.
------------------------------------------------------------------
*/
    public Product? GetProductById(int productId)
    {
        return _context.Products.FirstOrDefault(p => p.ProductId == productId);
    }

/*
------------------------------------------------------------------
Method: INSERT a new product in product catalogue.
------------------------------------------------------------------
*/
    public int InsertProduct(string productName, string description, double productPrice, int quantityInStock)
    {
        var product = new Product (productName, description, productPrice, quantityInStock);
        _context.Products.Add(product);

        int effectedEntries = _context.SaveChanges();
        return effectedEntries;
    }

/*
------------------------------------------------------------------
Method: Edit/ Update a product product in product catalogue. 
------------------------------------------------------------------
*/
    public int UpdateProduct(int id, string productName, string description, double productPrice, int quantityInStock)
    {
        var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
        if (product == null)
        {
            return 0;
        }
        
        product.UpdateProductDetails(productName, description, productPrice, quantityInStock);

        int effectedEntries = _context.SaveChanges();
        return effectedEntries;     

    }

/*
------------------------------------------------------------------
Method: Delete a product product in product catalogue. 
------------------------------------------------------------------
*/
    public int DeleteProduct(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
        if (product == null)
        {
            return 0;
        }

        _context.Products.Remove(product);

        int effectedEntries = _context.SaveChanges();
        return effectedEntries;
    }

/*
==========================================================================================
Method: Checks if a product is referenced in order_details (prevents delete due to FK constraint).
Parameter: productId = the product to check.
Returns: 'true' if this product is used in order_details. Otherwise 'false'.
==========================================================================================
*/
    public bool IsProductInUse(int productId)
    {
        bool result = _context.OrderDetails.Any(od => od.ProductId == productId);
        return result;
    }
}
