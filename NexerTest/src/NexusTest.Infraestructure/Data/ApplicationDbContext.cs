using Microsoft.EntityFrameworkCore;
using NexusTest.Domain.Entities;
using NexusTest.SharedKernel.Data;

namespace NexusTest.Infraestructure.Data
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        public async Task CommitAsync()
        {
            await base.SaveChangesAsync();
        }
    }
}
