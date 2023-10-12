using Common.Infraestructure.Adapters.EventBus.RabbitMq;
using ESCMB.Application.Repositories.Sql;
using ESCMB.Infraestructure.Repositories.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ESCMB.Infraestructure.Registrations
{
    /// <summary>
    /// Aqui se deben registrar todas las dependencias de la capa de infraestructura
    /// </summary>
    public static class InfraestructureDependenciesRegistration
    {
        public static IServiceCollection AddInfraestructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            /* Database Context */
            services.AddSqlServerRepositories(configuration);

            /* EventBus */
            services.AddEventBus();

            return services;
        }

        private static IServiceCollection AddSqlServerRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Repositories.Sql.StoreDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
            }, ServiceLifetime.Scoped);

            /* Sql Repositories */
            services.AddTransient<Application.Repositories.Sql.IDummyEntityRepository, Repositories.Sql.DummyEntityRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();

            return services;
        }
    }
}
