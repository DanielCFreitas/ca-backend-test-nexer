using Microsoft.EntityFrameworkCore;
using NexusTest.Infraestructure.Data;

namespace NexusTest.Api.Configuration
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // Gerar Migration para alguma conexao especifica do banco de dados
            //services.AddDbContext<FlorestaDbContext>(options =>
            //   options.UseNpgsql("User ID=postgres;Password=admin;Host=localhost;Port=5432;Database=cliente_1_floresta;"));

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                options.UseNpgsql(connectionString);
                options.EnableSensitiveDataLogging();
                options.LogTo(Console.WriteLine);
            });
        }
    }
}
