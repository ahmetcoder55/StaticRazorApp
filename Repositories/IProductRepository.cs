using Models;

namespace Repositories
{
    public interface IProductRepository
    {
         Task<List<Product>> GetAllProductsAsync();

        Task<Product> GetByIdProductAsync(int id);

        Task AddProductAsync(Product product);
    }
}