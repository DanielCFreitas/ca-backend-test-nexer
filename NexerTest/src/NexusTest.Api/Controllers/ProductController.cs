using Microsoft.AspNetCore.Mvc;
using NexerTest.Api.DTO.Request;
using NexerTest.Api.Services.Interfaces;
using NexerTest.SharedKernel.Api;
using System.ComponentModel.DataAnnotations;

namespace NexerTest.Api.Controllers
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
            var product = await _productService.ProductsList();
            return BaseResponse(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await _productService.SearchProductById(id);
            if (product == null)
                return BaseResponse(new ValidationResult("Product not found"));
            return BaseResponse(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddProductRequest request)
        {
            await _productService.AddProduct(request);
            return BaseResponse();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateProductRequest request)
        {
            var validationResult = await _productService.UpdateProduct(id, request);
            return BaseResponse(validationResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await _productService.DeleteProductById(id);
            if (product == null)
                return BaseResponse(new ValidationResult("Product not found"));
            return BaseResponse(product);
        }
    }
}
