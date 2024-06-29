using NexerTest.Domain.Entities;
using NexerTest.SharedKernel.Data;

namespace NexerTest.Domain.Repositories
{
    /// <summary>
    /// Repository for the product entity
    /// </summary>
    public interface IProductRepository : IRepositoryBase<Product>
    {
        /// <summary>
        /// Register a new product in the database
        /// </summary>
        /// <param name="product">Product that will be registered</param>
        void AddProduct(Product product);

        /// <summary>
        /// Search product by ID
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Retorna o produto encontrado atraves do id</returns>
        Task<Product?> SearchProductById(Guid id);

        /// <summary>
        /// List the products that are saved
        /// </summary>
        /// <returns>List of products found</returns>
        Task<IEnumerable<Product>> ListProducts();

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="product">Product that will be updated</param>
        void UpdateProduct(Product product);

        /// <summary>
        /// Deletes a product
        /// </summary>
        /// <param name="product">Product that will be excluded</param>
        void DeleteProduct(Product product);
    }
}
