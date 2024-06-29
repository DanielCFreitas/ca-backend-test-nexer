using Microsoft.EntityFrameworkCore;
using NexerTest.Domain.Entities;
using NexerTest.Domain.Repositories;
using NexerTest.Infraestructure.Data;
using NexerTest.SharedKernel.Data;

namespace NexerTest.Infraestructure.Data.Repositories
{
    public class BillingRepository : IBillingRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BillingRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IUnitOfWork unitOfWork => _applicationDbContext;

        public void AddBilling(Billing billing)
        {
            _applicationDbContext.Add(billing);
        }
        public async Task<IEnumerable<Billing>> ListBillings()
        {
            return await _applicationDbContext.Billing
                .Include(billing => billing.Customer)
                .Include(billing => billing.BillingLines)
                    .ThenInclude(billingLine => billingLine.Product)
                .ToListAsync();
        }

        public void Dispose()
        {
            _applicationDbContext.Dispose();
        }
    }
}
