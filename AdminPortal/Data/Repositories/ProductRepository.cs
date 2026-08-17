using MySqlConnector;

namespace AdminPortal.Data.Repositories;

public class ProductRepository: IProductRepository
{
    private readonly Database _database;
    private readonly AppDbContext _context;

    public ProductRepository(Database database, AppDbContext context)
    {
        _database = database;
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
    Method: INSERT a new product in product catalogue. 
    ------------------------------------------------------------------
    */

    public int InsertProduct(string productName, string description, double productPrice, int quantityInStock)
    {
        var product = new Product (productName, description, productPrice, quantityInStock);
        _context.Products.Add(product);
        return _context.SaveChanges();
    }

    /*
   ------------------------------------------------------------------
   Method: Edit/ Update a product product in product catalogue. 
   ------------------------------------------------------------------
   */

    public int UpdateProduct(int id, string productName, string description, double productPrice, int quantityInStock)
    {
        using var connection = _database.GetConnection();
        connection.Open();

        string query = @"
        UPDATE 
            product_catalogue
        SET 
            product_name = @product_name,
            description = @description,
            product_price = @product_price,
            quantity_in_stock = @quantity_in_stock
        WHERE 
            product_id = @product_id;
        ";

        MySqlCommand myCommand = new MySqlCommand(query, connection);
        myCommand.Parameters.AddWithValue("@product_name", productName);
        myCommand.Parameters.AddWithValue("@description", description);
        myCommand.Parameters.AddWithValue("@product_price", productPrice);
        myCommand.Parameters.AddWithValue("@quantity_in_stock", quantityInStock);
        myCommand.Parameters.AddWithValue("@product_id", id);

        int affectedRows = myCommand.ExecuteNonQuery();
        return affectedRows;
    }

    /*
  ------------------------------------------------------------------
  Method: Delete a product product in product catalogue. 
  ------------------------------------------------------------------
  */
    public int DeleteProduct(int id)
    {
        using var connection = _database.GetConnection();
        connection.Open();

        string query = @"
        DELETE 
        FROM 
        product_catalogue
        WHERE
        product_id = @product_id;
        ";

        MySqlCommand myCommand = new MySqlCommand(query, connection);
        myCommand.Parameters.AddWithValue("@product_id", id);

        int affectedRows = myCommand.ExecuteNonQuery();
        return affectedRows;
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
        using var connection = _database.GetConnection();
        connection.Open();

        string query = @"
        SELECT 1
        FROM order_details
        WHERE product_id = @product_id
        LIMIT 1;
        ";

        MySqlCommand myCommand = new MySqlCommand(query, connection);
        myCommand.Parameters.AddWithValue("@product_id", productId);

        var result = myCommand.ExecuteScalar();
        return result != null;
    }
}