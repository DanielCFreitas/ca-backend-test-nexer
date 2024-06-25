using NexusTest.Api.DTO;
using NexusTest.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace NexusTest.Api.Services.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// Cadastra um novo produto
        /// </summary>
        /// <returns></returns>
        Task CadastrarProduto(CadastrarProdutoRequest request);

        /// <summary>
        /// Lista todos os produtos
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Product>> ListarProdutos();

        /// <summary>
        /// Busca produto por id
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns></returns>
        Task<Product?> BuscarProdutoPorId(Guid id);

        /// <summary>
        /// Atualiza um produto no banco
        /// </summary>
        /// <param name="request">Produtos para ser atualizado</param>
        /// <returns></returns>
        Task<ValidationResult> AtualizarProduto(Guid id, AtualizarProdutoRequest request);

        /// <summary>
        /// Exclui um produto atraves do id
        /// </summary>
        /// <param name="id">id do produto</param>
        /// <returns></returns>
        Task<ValidationResult> ExcluirProduto(Guid id);
    }
}
