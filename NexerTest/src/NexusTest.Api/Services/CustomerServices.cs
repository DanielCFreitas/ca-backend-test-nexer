using NexusTest.Api.Services.Interfaces;
using NexusTest.Domain.Entities;
using NexusTest.Domain.Repositories;
using NexusTest.SharedKernel.Api;

namespace NexusTest.Api.Services
{
    public class CustomerServices : BaseService, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerServices(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task AtualizarCliente(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> BuscarClientePorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task CadastrarCliente()
        {
            throw new NotImplementedException();
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
