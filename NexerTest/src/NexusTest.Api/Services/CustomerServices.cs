using NexusTest.Api.DTO;
using NexusTest.Api.Services.Interfaces;
using NexusTest.Domain.Entities;
using NexusTest.Domain.Repositories;
using NexusTest.SharedKernel.Api;
using System.ComponentModel.DataAnnotations;

namespace NexusTest.Api.Services
{
    public class CustomerServices : BaseService, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerServices(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ValidationResult> AtualizarCliente(Guid id, AtualizarClienteRequest request)
        {
            var cliente = await _customerRepository.SearchCustomerById(id);

            if (cliente is null)
                return new ValidationResult("Cliente não encontrado");

            cliente.ChangeName(request.Name);
            cliente.ChangeEmail(request.Email);
            cliente.ChangeAddress(request.Address);

            _customerRepository.UpdateCustomer(cliente);
            await SalvarAlteracoes(_customerRepository.unitOfWork);
            return new ValidationResult(string.Empty);
        }

        public async Task<Customer?> BuscarClientePorId(Guid id)
        {
            return await _customerRepository.SearchCustomerById(id);
        }

        public async Task CadastrarCliente(CadastrarClienteRequest request)
        {
            var cliente = new Customer(request.Name, request.Email, request.Address);
            _customerRepository.AddCustomer(cliente);
            await SalvarAlteracoes(_customerRepository.unitOfWork);
        }

        public Task ExcluirCliente(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> ListarClientes()
        {
            return await _customerRepository.ListCustomers();
        }
    }
}
