using NexerTest.Domain.Entities;
using NexerTest.SharedKernel.Data;

namespace NexerTest.Domain.Repositories
{
    /// <summary>
    /// Repository for the billing entity
    /// </summary>
    public interface IBillingRepository : IRepositoryBase<Billing>
    {
        /// <summary>
        /// Add new charge to the database
        /// </summary>
        /// <param name="billing">Billing that must be registered</param>
        public void AddBilling(Billing billing);

        /// <summary>
        /// List all billings
        /// </summary>
        /// <returns>List of registered billings</returns>
        public Task<IEnumerable<Billing>> ListBillings();
    }
}
