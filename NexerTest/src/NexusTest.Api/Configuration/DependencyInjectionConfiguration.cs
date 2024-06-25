using NexusTest.Api.Services;
using NexusTest.Api.Services.Interfaces;
using NexusTest.Domain.Repositories;
using NexusTest.Infraestructure.Data;
using NexusTest.Infraestructure.Data.Repositories;

namespace NexusTest.Api.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();

            // Repositories
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            // Services
            services.AddScoped<ICustomerService, CustomerServices>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
