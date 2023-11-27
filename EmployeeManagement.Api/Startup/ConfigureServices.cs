
using Application;
using Infrastructure;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
using EmployeeManagement.Api.Filters;

namespace EmployeeManagement.Api.Startup
{
    public static class ConfigureServices
    {
        public static IServiceCollection RegisterService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddApplication();
            services.AddControllers(options =>
            {
                options.Filters.Add<ApiExceptionFilterAttribute>();
            })
                .AddFluentValidation();
            services.AddCustomModelState();
            services.AddEndpointsApiExplorer();

            services.AddPersistence(configuration);

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Employee Management",
                    Version = "v1"
                });
            });


            services.AddRouting(option =>
            {
                option.LowercaseUrls = true;
                option.LowercaseQueryStrings = true;
            });



            return services;

        }
    }
}
