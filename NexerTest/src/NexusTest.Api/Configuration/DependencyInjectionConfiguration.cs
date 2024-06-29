using NexerTest.Api.Services;
using NexerTest.Api.Services.Interfaces;
using NexerTest.Domain.Repositories;
using NexerTest.Infraestructure.Data;
using NexerTest.Infraestructure.Data.Repositories;

namespace NexerTest.Api.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();

            // Repositories
            services.AddScoped<IBillingRepository, BillingRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            // Services
            services.AddScoped<IBillingService, BillingService>();
            services.AddScoped<ICustomerService, CustomerServices>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
