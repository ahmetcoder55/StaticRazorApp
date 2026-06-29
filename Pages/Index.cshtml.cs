using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Repositories;

namespace StaticRazorApp.Pages;

public class IndexModel : PageModel
{
    private readonly IProductRepository _repository;

    public IndexModel(IProductRepository repository)
    {
        _repository = repository;
    }

    public List<Product> Products { get; set; } =new();

    public async Task OnGetAsync()
    {
       Products=await _repository.GetAllProductsAsync();
    }
}
