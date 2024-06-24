using Microsoft.AspNetCore.Mvc;
using NexusTest.Api.DTO;
using NexusTest.Api.Services.Interfaces;
using NexusTest.SharedKernel.Api;

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

        [HttpPost] 
        public async Task<IActionResult> Post([FromBody] CadastrarClienteRequest request)
        {
            await _customerService.CadastrarCliente(request);
            return BaseResponse();
        }
    }
}
