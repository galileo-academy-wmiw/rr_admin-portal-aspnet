using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPortal.Pages.Products;

public class CreateModel : PageModel
{
    private readonly IProductService _productService;

    [BindProperty]
    [Required(ErrorMessage = "Product name is required.")]
    [Display(Name = "Name")]
    public string ProductName { get; set; } = "";

    [BindProperty]
    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; } = "";

    [BindProperty]
    [Range(0.1, double.MaxValue, ErrorMessage = "Price must be higher than 0.01.")]
    [Display(Name = "Price")]
    public double ProductPrice { get; set; }

    [BindProperty]
    [Range(0, 10000, ErrorMessage = "Quantity in stock cannot be negative.")]
    [Display(Name = "Quantity in stock")]
    public int QuantityInStock { get; set; }

    public CreateModel(IProductService productService)
    {
        _productService = productService;
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        bool productAdded = _productService.AddProduct(
            ProductName,
            Description,
            ProductPrice,
            QuantityInStock);

        if (!productAdded)
        {
            ModelState.AddModelError("", "The product could not be added.");
            return Page();
        }

        return RedirectToPage("/Products/Index");
    }
}