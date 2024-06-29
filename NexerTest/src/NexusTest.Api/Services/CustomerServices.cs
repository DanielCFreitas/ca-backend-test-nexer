using NexerTest.Api.DTO.Request;
using NexerTest.Api.Services.Interfaces;
using NexerTest.Domain.Entities;
using NexerTest.Domain.Repositories;
using NexerTest.SharedKernel.Api;
using System.ComponentModel.DataAnnotations;

namespace NexerTest.Api.Services
{
    public class CustomerServices : BaseService, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerServices(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ValidationResult> UpdateCustomer(Guid id, UpdateCustomerRequest request)
        {
            var customer = await _customerRepository.SearchCustomerById(id);

            if (customer is null)
                return new ValidationResult("Customer not found");

            customer.ChangeName(request.Name);
            customer.ChangeEmail(request.Email);
            customer.ChangeAddress(request.Address);

            _customerRepository.UpdateCustomer(customer);
            await SaveChanges(_customerRepository.unitOfWork);
            return new ValidationResult(string.Empty);
        }

        public async Task<Customer?> SearchCustomerById(Guid id)
        {
            return await _customerRepository.SearchCustomerById(id);
        }

        public async Task AddCustomer(AddCustomerRequest request)
        {
            var customer = new Customer(Guid.NewGuid(), request.Name, request.Email, request.Address);
            _customerRepository.AddCustomer(customer);
            await SaveChanges(_customerRepository.unitOfWork);
        }

        public async Task<ValidationResult> DeleteCustomerById(Guid id)
        {
            var customer = await _customerRepository.SearchCustomerById(id);

            if (customer is null)
                return new ValidationResult("Customer not found");

            _customerRepository.DeleteCustomer(customer);
            await SaveChanges(_customerRepository.unitOfWork);
            return new ValidationResult(string.Empty);
        }

        public async Task<IEnumerable<Customer>> CustomersList()
        {
            return await _customerRepository.ListCustomers();
        }
    }
}
