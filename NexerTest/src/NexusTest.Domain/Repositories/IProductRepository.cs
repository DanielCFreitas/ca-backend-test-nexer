using NexusTest.Domain.Entities;
using NexusTest.SharedKernel.Data;

namespace NexusTest.Domain.Repositories
{
    public interface IProductRepository : RepositoryBase<Product>
    {
        /// <summary>
        /// Cadastra um novo produto no banco de dados
        /// </summary>
        /// <param name="product">Produto que sera cadastrado</param>
        void AddProduct(Product product);

        /// <summary>
        /// Busca produto por Id
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns>Retorna o produto encontrado atraves do id</returns>
        Task<Product?> SearchProductById(Guid id);

        /// <summary>
        /// Lista os produtos que estao salvos
        /// </summary>
        /// <returns>Lista de produtos encontrados</returns>
        Task<IEnumerable<Product>> ListProducts();

        /// <summary>
        /// Atualiza produto
        /// </summary>
        /// <param name="product">Produto que sera atualizado</param>
        void UpdateProduct(Product product);

        /// <summary>
        /// Exclui um produto 
        /// </summary>
        /// <param name="product">Produto que sera excluido</param>
        void DeleteProduct(Product product);
    }
}
