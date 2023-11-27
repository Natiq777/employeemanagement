using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddDbContext<EmployeeManagementDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("EmployeeManagementDb"),
                b => b.MigrationsAssembly(typeof(EmployeeManagementDBContext).Assembly.FullName)), ServiceLifetime.Transient);

            _ = services.AddScoped<IEmployeeManagementDBContext>(provider => provider.GetService<EmployeeManagementDBContext>());
            return services;
        }
    }
}
