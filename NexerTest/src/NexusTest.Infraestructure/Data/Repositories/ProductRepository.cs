using Microsoft.EntityFrameworkCore;
using NexusTest.Domain.Entities;
using NexusTest.Domain.Repositories;
using NexusTest.SharedKernel.Data;

namespace NexusTest.Infraestructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IUnitOfWork unitOfWork => _applicationDbContext;

        public void AddProduct(Product product)
        {
            _applicationDbContext.Products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            _applicationDbContext.Products.Remove(product);
        }

        public async Task<IEnumerable<Product>> ListProducts()
        {
            return await _applicationDbContext.Products.ToListAsync();
        }

        public async Task<Product?> SearchProductById(Guid id)
        {
            return await _applicationDbContext.Products.FindAsync(id);
        }

        public void UpdateProduct(Product product)
        {
            _applicationDbContext.Products.Update(product);
        }

        public void Dispose()
        {
            _applicationDbContext.Dispose();
        }
    }
}
