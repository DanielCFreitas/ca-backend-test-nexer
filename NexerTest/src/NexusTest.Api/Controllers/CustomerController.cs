using Microsoft.AspNetCore.Mvc;
using NexerTest.Api.DTO.Request;
using NexerTest.Api.Services.Interfaces;
using NexerTest.SharedKernel.Api;
using System.ComponentModel.DataAnnotations;

namespace NexerTest.Api.Controllers
{
    [Route("/[controller]")]
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Returns list of customers
        /// </summary>
        /// <returns>List of billings</returns>
        /// <response code="200">OK</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _customerService.CustomersList();
            return BaseResponse(customers);
        }

        /// <summary>
        /// Returns a customer by ID
        /// </summary>
        /// <returns>Customer</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var customer = await _customerService.SearchCustomerById(id);
            if (customer == null)
                return BaseResponse(new ValidationResult("Customer not found"));
            return BaseResponse(customer);
        }

        /// <summary>
        /// Add a new customer
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCustomerRequest request)
        {
            await _customerService.AddCustomer(request);
            return BaseResponse();
        }

        /// <summary>
        /// Update a customer
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateCustomerRequest request)
        {
            var validationResult = await _customerService.UpdateCustomer(id, request);
            return BaseResponse(validationResult);
        }

        /// <summary>
        /// Delete a customer
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var customer = await _customerService.DeleteCustomerById(id);
            if (customer == null)
                return BaseResponse(new ValidationResult("ClienteCustomer not found"));
            return BaseResponse(customer);
        }
    }
}
