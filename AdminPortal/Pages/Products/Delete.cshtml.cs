using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPortal.Pages.Products;

[Authorize(Roles = "Admin")]
public class DeleteModel : PageModel
{
    private readonly IProductService _productService;

    public Product Product { get; private set; } = null!;

    public DeleteModel(IProductService productService)
    {
        _productService = productService;
    }

    public IActionResult OnGet(int id)
    {
        Product? product = _productService.GetProductById(id);

        if (product == null)
        {
            return NotFound();
        }

        Product = product;
        return Page();
    }

    public IActionResult OnPost(int id)
    {
        bool productDeleted = _productService.DeleteProduct(id);

        if (productDeleted)
        {
            return RedirectToPage("/Products/Index");
        }

        Product? product = _productService.GetProductById(id);

        if (product == null)
        {
            return NotFound();
        }

        Product = product;
        ModelState.AddModelError("", "The product cannot be deleted because it is used in an order.");
        return Page();
    }
}
