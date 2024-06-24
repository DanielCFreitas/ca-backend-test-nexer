using Microsoft.EntityFrameworkCore;
using NexusTest.Domain.Entities;
using NexusTest.Domain.Repositories;
using NexusTest.SharedKernel.Data;

namespace NexusTest.Infraestructure.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CustomerRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IUnitOfWork? unitOfWork => _applicationDbContext;

        public void AddCustomer(Customer customer)
        {
            _applicationDbContext.Add(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            _applicationDbContext.Remove(customer);
        }

        public async Task<IEnumerable<Customer>> ListCustomers()
        {
            return await _applicationDbContext.Customers.ToListAsync();
        }

        public async Task<Customer?> SearchCustomerById(Guid id)
        {
            return await _applicationDbContext.Customers.FindAsync(id);
        }

        public void UpdateCustomer(Customer customer)
        {
            _applicationDbContext.Customers.Update(customer);
        }

        public void Dispose()
        {
            _applicationDbContext.Dispose();
        }
    }
}
