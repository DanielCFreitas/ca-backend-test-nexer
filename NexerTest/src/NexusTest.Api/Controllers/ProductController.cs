using Microsoft.AspNetCore.Mvc;
using NexusTest.Api.DTO;
using NexusTest.Api.Services.Interfaces;
using NexusTest.SharedKernel.Api;
using System.ComponentModel.DataAnnotations;

namespace NexusTest.Api.Controllers
{
    [Route("/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var produtos = await _productService.ListarProdutos();
            return BaseResponse(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var produto = await _productService.BuscarProdutoPorId(id);
            if (produto == null)
                return BaseResponse(new ValidationResult("Produto não encontrado"));
            return BaseResponse(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CadastrarProdutoRequest request)
        {
            await _productService.CadastrarProduto(request);
            return BaseResponse();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] AtualizarProdutoRequest request)
        {
            var validationResult = await _productService.AtualizarProduto(id, request);
            return BaseResponse(validationResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var produto = await _productService.ExcluirProduto(id);
            if (produto == null)
                return BaseResponse(new ValidationResult("Produto não encontrado"));
            return BaseResponse(produto);
        }
    }
}
