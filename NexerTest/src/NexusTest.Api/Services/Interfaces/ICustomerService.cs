using NexerTest.Api.DTO.Request;
using NexerTest.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace NexerTest.Api.Services.Interfaces
{
    public interface ICustomerService
    {
        /// <summary>
        /// Add a new customer
        /// </summary>
        /// <returns></returns>
        Task AddCustomer(AddCustomerRequest request);

        /// <summary>
        /// List all customers
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Customer>> CustomersList();

        /// <summary>
        /// Find customer by ID
        /// </summary>
        /// <param name="id">Customer ID</param>
        /// <returns></returns>
        Task<Customer?> SearchCustomerById(Guid id);

        /// <summary>
        /// Update customer
        /// </summary>
        /// <param name="request">Customer updated</param>
        /// <returns></returns>
        Task<ValidationResult> UpdateCustomer(Guid id, UpdateCustomerRequest request);

        /// <summary>
        /// Delete a customer by ID
        /// </summary>
        /// <param name="id">Customer ID</param>
        /// <returns></returns>
        Task<ValidationResult> DeleteCustomerById(Guid id);
    }
}
