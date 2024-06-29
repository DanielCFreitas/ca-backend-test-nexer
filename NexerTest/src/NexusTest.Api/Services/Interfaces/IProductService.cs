using NexerTest.Api.DTO.Request;
using NexerTest.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace NexerTest.Api.Services.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// Add a new Product
        /// </summary>
        /// <returns></returns>
        Task AddProduct(AddProductRequest request);

        /// <summary>
        /// Products List
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Product>> ProductsList();

        /// <summary>
        /// Search a product by ID
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns></returns>
        Task<Product?> SearchProductById(Guid id);

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <param name="request">Updated product</param>
        /// <returns></returns>
        Task<ValidationResult> UpdateProduct(Guid id, UpdateProductRequest request);

        /// <summary>
        /// Deletes a product using id
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns></returns>
        Task<ValidationResult> DeleteProductById(Guid id);
    }
}
