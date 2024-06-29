using NexerTest.Api.DTO.Request;
using NexerTest.Api.Services.Interfaces;
using NexerTest.Domain.Entities;
using NexerTest.Domain.Repositories;
using NexerTest.SharedKernel.Api;
using System.ComponentModel.DataAnnotations;

namespace NexerTest.Api.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ValidationResult> UpdateProduct(Guid id, UpdateProductRequest request)
        {
            var product = await _productRepository.SearchProductById(id);

            if (product is null)
                return new ValidationResult("Product not found");

            product.ChangeName(request.Name);

            _productRepository.UpdateProduct(product);
            await SaveChanges(_productRepository.unitOfWork);
            return new ValidationResult(string.Empty);
        }

        public async Task<Product?> SearchProductById(Guid id)
        {
            return await _productRepository.SearchProductById(id);
        }

        public async Task AddProduct(AddProductRequest request)
        {
            var product = new Product(Guid.NewGuid(), request.Name);
            _productRepository.AddProduct(product);
            await SaveChanges(_productRepository.unitOfWork);
        }

        public async Task<ValidationResult> DeleteProductById(Guid id)
        {
            var product = await _productRepository.SearchProductById(id);

            if (product is null)
                return new ValidationResult("Product not found");

            _productRepository.DeleteProduct(product);
            await SaveChanges(_productRepository.unitOfWork);
            return new ValidationResult(string.Empty);
        }

        public async Task<IEnumerable<Product>> ProductsList()
        {
            return await _productRepository.ListProducts();
        }
    }
}
