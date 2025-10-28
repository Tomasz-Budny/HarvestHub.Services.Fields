using HarvestHub.Shared.Authentication;
using HarvestHub.Shared.Authentication.Options;
using HarvestHub.Shared.Events;
using HarvestHub.Shared.Exceptions;
using HarvestHub.Shared.Messaging;
using Humanizer.Configuration;
using MassTransit;
using MassTransit.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace HarvestHub.Shared
{
    public static class Extensions
    {
        public static IServiceCollection AddShared(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEvents();
            services.AddMessaging();
            services.AddScoped<ErrorHandlerMiddleware>();
            services.AddSingleton<IExceptionToResponseMapper, ExceptionToResponseMapper>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddScoped<IUserContextService, UserContextService>();
            services.AddHttpContextAccessor();

            var jwtOptions = configuration.GetOptions<JwtOptions>(JwtOptions.SectionName);
            services.AddSingleton(Options.Create(jwtOptions));

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtOptions.Secret))
                    };
                }
            );

            return services;
        }

        public static TOptions GetOptions<TOptions>(this IConfiguration configuration, string sectionName) where TOptions : new()
        {
            var options = new TOptions();
            configuration.GetSection(sectionName).Bind(options);

            return options;
        }

        public static IServiceCollection AddHarvestHubMessaging(
            this IServiceCollection services,
            IConfiguration cfg,
            string serviceName,
            Action<IBusRegistrationConfigurator>? addConsumers = null)
        {
            services.AddMassTransit(x =>
            {
                addConsumers?.Invoke(x);

                x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter(serviceName, includeNamespace: false));

                x.AddConfigureEndpointsCallback((context, name, e) =>
                {
                    e.PrefetchCount = 16;
                    e.ConcurrentMessageLimit = 8;
                });

                x.UsingRabbitMq((context, bus) =>
                {
                    var hostUri = cfg["Rabbit:Host"] ?? "amqp://guest:guest@localhost:5672";
                    bus.Host(new Uri(hostUri));

                    bus.UseMessageRetry(r => r.Exponential(
                        retryLimit: 5,
                        minInterval: TimeSpan.FromSeconds(1),
                        maxInterval: TimeSpan.FromSeconds(30),
                        intervalDelta: TimeSpan.FromSeconds(5)));

                    bus.UseDelayedRedelivery(r => r.Intervals(
                        TimeSpan.FromSeconds(10),
                        TimeSpan.FromSeconds(30),
                        TimeSpan.FromMinutes(2)));

                    bus.UseInMemoryOutbox(context);

                    bus.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}
