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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _customerService.CustomersList();
            return BaseResponse(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var customer = await _customerService.SearchCustomerById(id);
            if (customer == null)
                return BaseResponse(new ValidationResult("Customer not found"));
            return BaseResponse(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCustomerRequest request)
        {
            await _customerService.AddCustomer(request);
            return BaseResponse();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateCustomerRequest request)
        {
            var validationResult = await _customerService.UpdateCustomer(id, request);
            return BaseResponse(validationResult);
        }

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
