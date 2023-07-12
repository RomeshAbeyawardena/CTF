using CTF.Features;
using Microsoft.Extensions.DependencyInjection;
using RST.DependencyInjection.Extensions;
using RST.EntityFrameworkCore.Extensions;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CTF.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices<TApplicationServices>(this IServiceCollection services, 
            Func<TApplicationServices, string?> getConnectionString, string migrationAssemblyName, params Assembly[] assemblies)
            where TApplicationServices : class
        {
            return services
                .AddServicesWithRegisterAttribute(opt => opt.ConfigureCoreServices = true, assemblies)
                .AddTransient<IDbConnection>(s =>
                {
                    var applicationServices = s.GetRequiredService<TApplicationServices>();
                    var connectionString = getConnectionString(applicationServices);

                    return new SqlConnection(connectionString);
                })
                .AddCoreServices()
                .AddDbContextAndRepositories<CTFDbContext>(typeof(CTFEntityRepository<>), (s, opt) =>
                {
                    var applicationServices = s.GetRequiredService<TApplicationServices>();
                    var connectionString = getConnectionString(applicationServices);
                    if (!string.IsNullOrEmpty(connectionString))
                    {
                        opt.UseSqlServer(connectionString, opt => opt.MigrationsAssembly(migrationAssemblyName));
                    }
                });
        }
    }
}
