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

        /// <summary>
        /// Returns list of products
        /// </summary>
        /// <returns>List of billings</returns>
        /// <response code="200">OK</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var product = await _productService.ProductsList();
            return BaseResponse(product);
        }

        /// <summary>
        /// Returns a product by ID
        /// </summary>
        /// <returns>Customer</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await _productService.SearchProductById(id);
            if (product == null)
                return BaseResponse(new ValidationResult("Product not found"));
            return BaseResponse(product);
        }

        /// <summary>
        /// Add a new product
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddProductRequest request)
        {
            await _productService.AddProduct(request);
            return BaseResponse();
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateProductRequest request)
        {
            var validationResult = await _productService.UpdateProduct(id, request);
            return BaseResponse(validationResult);
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
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
