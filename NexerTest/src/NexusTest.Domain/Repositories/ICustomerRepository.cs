using NexerTest.Domain.Entities;
using NexerTest.SharedKernel.Data;

namespace NexerTest.Domain.Repositories
{
    /// <summary>
    /// Repository for the customer entity
    /// </summary>
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        /// <summary>
        /// Register a new customer in the database
        /// </summary>
        /// <param name="customer">Cliente que sera cadastrado</param>
        void AddCustomer(Customer customer);

        /// <summary>
        /// Search customer by ID
        /// </summary>
        /// <param name="id">Client ID</param>
        /// <returns>Returns the customer found using the id</returns>
        Task<Customer?> SearchCustomerById(Guid id);

        /// <summary>
        /// List the clients that are saved
        /// </summary>
        /// <returns>List of customers found</returns>
        Task<IEnumerable<Customer>> ListCustomers();

        /// <summary>
        /// Update client
        /// </summary>
        /// <param name="customer">Client to be updated</param>
        void UpdateCustomer(Customer customer);

        /// <summary>
        /// Deletes a customer
        /// </summary>
        /// <param name="customer">Customer who will be excluded</param>
        void DeleteCustomer(Customer customer);
    }
}
