using Microsoft.Extensions.DependencyInjection;
using HarvestHub.Services.Fields.Application;
using Microsoft.Extensions.Configuration;
using HarvestHub.Services.Fields.Infrastructure;

namespace HarvestHub.Services.Fields.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddFieldsModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplication();
            services.AddInfrastructure(configuration);

            return services;
        }
    }
}
