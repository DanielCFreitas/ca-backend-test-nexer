using NexerTest.Api.DTO.Request;
using NexerTest.Api.DTO.Response;
using System.ComponentModel.DataAnnotations;

namespace NexerTest.Api.Services.Interfaces
{
    public interface IBillingService
    {
        /// <summary>
        /// Register a new charge in the database
        /// </summary>
        /// <returns>Returns whether the process was successful or not</returns>
        Task<ValidationResult> AddBilling(AddBillingRequest request);

        /// <summary>
        /// Billings List
        /// </summary>
        /// <returns>Billings List</returns>
        Task<IEnumerable<BillingResponse>> BillingsList();
    }
}
