using Data;
using Models;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StaticContext _context;

        public ProductRepository(StaticContext context)
        {
            _context = context;
        }

        public Task AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            return Task.CompletedTask;
        }

        public  Task<List<Product>> GetAllProductsAsync()
        {
           return Task.FromResult(_context.Products);
        }

        public Task<Product> GetByIdProductAsync(int id)
        {
            return Task.FromResult(_context.Products.FirstOrDefault(x=>x.Id==id));
        }
    }
}