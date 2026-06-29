using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Repositories;

namespace StaticRazorApp.Pages
{
    public class AddProductModel : PageModel
    {
        private readonly IProductRepository _repository;
        private readonly IWebHostEnvironment _environment;

        public AddProductModel(IProductRepository reposiory, IWebHostEnvironment environment)
        {
            _repository = reposiory;
            _environment = environment;
        }



        [BindProperty]
        public Product NewProduct { get; set; } = new();

        [BindProperty]
        public IFormFile? ProductImage { get; set; }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
{
    // Artık validation kontrolünde ProductImage == null şartını kaldırdık
    if (!ModelState.IsValid)
    {
        return Page();
    }

    // 1. KULLANICI RESİM SEÇTİ Mİ?
    if (ProductImage != null && ProductImage.Length > 0)
    {
        // Benzersiz dosya adı üretimi
        var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(ProductImage.FileName)}";
        var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");

        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await ProductImage.CopyToAsync(fileStream);
        }

        // Seçilen resmin yolunu atıyoruz
        NewProduct.ImageUrl = $"~/uploads/{uniqueFileName}";
    }
    else
    {
        // 2. KULLANICI RESİM SEÇMEDİYSE: Otomatik yedek resmi bağlıyoruz
        NewProduct.ImageUrl = "~/uploads/no-image.png";
    }

    // ID Simülasyonu
    var products = await _repository.GetAllProductsAsync();
    NewProduct.Id = products.Any() ? products.Max(p => p.Id) + 1 : 1;

    // Servis üzerinden listeye ekleme
    await _repository.AddProductAsync(NewProduct);

    return RedirectToPage("Index");
}
    }
}