using Microsoft.AspNetCore.Mvc;
using NexusTest.Api.DTO;
using NexusTest.Api.Services.Interfaces;
using NexusTest.SharedKernel.Api;
using System.ComponentModel.DataAnnotations;

namespace NexusTest.Api.Controllers
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
            var clientes = await _customerService.ListarClientes();
            return BaseResponse(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var cliente = await _customerService.BuscarClientePorId(id);
            if (cliente == null)
                return BaseResponse(new ValidationResult("Cliente não encontrado"));
            return BaseResponse(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CadastrarClienteRequest request)
        {
            await _customerService.CadastrarCliente(request);
            return BaseResponse();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] AtualizarClienteRequest request)
        {
            var validationResult = await _customerService.AtualizarCliente(id, request);
            return BaseResponse(validationResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var cliente = await _customerService.ExcluirCliente(id);
            if (cliente == null)
                return BaseResponse(new ValidationResult("Cliente não encontrado"));
            return BaseResponse(cliente);
        }
    }
}
