using HarvestHub.Shared.Events;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HarvestHub.Services.Fields.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblies(typeof(Extensions).Assembly);
            });

            services.AddAutoMapper(typeof(Extensions).Assembly);

            services.Scan(s => s.FromAssemblies(Assembly.GetExecutingAssembly())
                .AddClasses(c => c.AssignableTo(typeof(IEventHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
