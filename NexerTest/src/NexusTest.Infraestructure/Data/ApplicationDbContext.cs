using Microsoft.EntityFrameworkCore;
using NexerTest.Domain.Entities;
using NexerTest.SharedKernel.Data;

namespace NexerTest.Infraestructure.Data
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Billing> Billing { get; set; }
        public DbSet<BillingLine> BillingLine { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public async Task CommitAsync()
        {
            await base.SaveChangesAsync();
        }
    }
}
