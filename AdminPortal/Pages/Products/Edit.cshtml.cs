using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPortal.Pages.Products;

public class EditModel : PageModel
{
    private readonly IProductService _productService;

    [BindProperty]
    public int ProductId { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Product name is required.")]
    [Display(Name = "Name")]
    public string ProductName { get; set; } = "";

    [BindProperty]
    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; } = "";

    [BindProperty]
    [Range(0.1, double.MaxValue, ErrorMessage = "Price must be at least 0.10.")]
    [Display(Name = "Price")]
    public double ProductPrice { get; set; }

    [BindProperty]
    [Range(0, 10000, ErrorMessage = "Quantity in stock cannot be negative.")]
    [Display(Name = "Quantity in stock")]
    public int QuantityInStock { get; set; }

    public EditModel(IProductService productService)
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

        ProductId = product.ProductId;
        ProductName = product.ProductName;
        Description = product.Description;
        ProductPrice = product.ProductPrice;
        QuantityInStock = product.QuantityInStock;

        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        bool productUpdated = _productService.UpdateProduct(
            ProductId,
            ProductName,
            Description,
            ProductPrice,
            QuantityInStock);

        if (!productUpdated)
        {
            ModelState.AddModelError("", "The product could not be updated.");
            return Page();
        }

        return RedirectToPage("/Products/Index");
    }
}
