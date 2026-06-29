using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Repositories;

namespace StaticRazorApp.Pages
{
    public class ProductDetailModel : PageModel
    {
        private readonly IProductRepository _productRepository;

    public ProductDetailModel(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    // Sayfada göstereceğimiz tek bir ürünü tutar
    public Product? Product { get; set; }

    // URL'den gelen 'id' parametresi doğrudan metoda düşer
    public async Task<IActionResult> OnGetAsync(int id)
    {
        Product = await _productRepository.GetByIdProductAsync(id);

        // Eğer bu ID'ye sahip bir ürün yoksa kullanıcıyı 404 sayfasına veya ana sayfaya postala
        if (Product == null)
        {
            return RedirectToPage("Index");
        }

        return Page();
    }
    }
}
