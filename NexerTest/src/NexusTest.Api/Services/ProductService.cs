using NexusTest.Api.DTO;
using NexusTest.Api.Services.Interfaces;
using NexusTest.Domain.Entities;
using NexusTest.Domain.Repositories;
using NexusTest.SharedKernel.Api;
using System.ComponentModel.DataAnnotations;

namespace NexusTest.Api.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ValidationResult> AtualizarProduto(Guid id, AtualizarProdutoRequest request)
        {
            var produto = await _productRepository.SearchProductById(id);

            if (produto is null)
                return new ValidationResult("Produto não encontrado");

            produto.ChangeName(request.Name);

            _productRepository.UpdateProduct(produto);
            await SalvarAlteracoes(_productRepository.unitOfWork);
            return new ValidationResult(string.Empty);
        }

        public async Task<Product?> BuscarProdutoPorId(Guid id)
        {
            return await _productRepository.SearchProductById(id);
        }

        public async Task CadastrarProduto(CadastrarProdutoRequest request)
        {
            var produto = new Product(request.Name);
            _productRepository.AddProduct(produto);
            await SalvarAlteracoes(_productRepository.unitOfWork);
        }

        public async Task<ValidationResult> ExcluirProduto(Guid id)
        {
            var produto = await _productRepository.SearchProductById(id);

            if (produto is null)
                return new ValidationResult("Produto não encontrado");

            _productRepository.DeleteProduct(produto);
            await SalvarAlteracoes(_productRepository.unitOfWork);
            return new ValidationResult(string.Empty);
        }

        public async Task<IEnumerable<Product>> ListarProdutos()
        {
            return await _productRepository.ListProducts();
        }
    }
}
