using ApiApplication.Data;
using Data.Contexto;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ApiApplication.Configuration
{
    public static class HealthChecksConfig
    {

        public static void AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecksUI(option => { option.AddHealthCheckEndpoint("API com Health Checks", "/health"); })
                    .AddInMemoryStorage();


            services.AddHealthChecks()
                    .AddCheck<CustomHealthChecks>("API")
                    .AddSqlServer(configuration.GetConnectionString("DefaultConnection"), name: "SQL Server")
                    .AddDbContextCheck<AppDbContext>($"{nameof(AppDbContext)}(EF DbContext)", customTestQuery: CustomTestQueryAsync)
                    .AddDbContextCheck<ApplicationDbContext>($"{nameof(ApplicationDbContext)}(EF IdentityDbContext)");

        }

        public static void MapHealthChecks(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapHealthChecks("/health", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            endpoints.MapHealthChecksUI(config =>
            {
                config.UIPath = "/status";
                config.AddCustomStylesheet("status.css");
            });
        }

        public static async Task<bool> CustomTestQueryAsync(AppDbContext context, CancellationToken cancellationToken = default)
        {
            var lstMigr = context.Database.GetPendingMigrations();
            if (lstMigr.Any())
            {                
                throw new System.Exception("Migration Pendente: " + lstMigr.First());
            }

            return await Task.FromResult(true);
  
        }

        public class CustomHealthChecks : IHealthCheck
        {
            public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
            {
                return Task.FromResult(new HealthCheckResult(
                status: HealthStatus.Healthy,
                description: "API está ON"
                ));
            }
        }


    }
}