using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPortal.Pages.Products;

public class IndexModel : PageModel
{
    private readonly IProductService _productService;

    public List<Product> Products { get; private set; } = [];

    public IndexModel(IProductService productService)
    {
        _productService = productService;
    }

    public void OnGet()
    {
        Products = _productService.GetAllProducts();
    }
}