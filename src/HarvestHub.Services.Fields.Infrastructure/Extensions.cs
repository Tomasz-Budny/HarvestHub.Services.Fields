using HarvestHub.Services.Fields.Infrastructure.Persistance;
using HarvestHub.Shared.Database.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HarvestHub.Shared;
using HarvestHub.Services.Fields.Core.Fields.Repositories;
using HarvestHub.Services.Fields.Infrastructure.Persistance.Repositories;
using HarvestHub.Services.Fields.Core.Owners.Repositories;
using HarvestHub.Services.Fields.Infrastructure.Services.Options;
using Microsoft.Extensions.Options;
using HarvestHub.Services.Fields.Application.Services;
using HarvestHub.Services.Fields.Infrastructure.Services;
using HarvestHub.Services.Fields.Application.CultivationHistories.Services;
using HarvestHub.Services.Fields.Core.CultivationHistories.Repositories;
using HarvestHub.Services.CultivationHistories.Infrastructure.Persistance.Services;

namespace HarvestHub.Services.Fields.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetOptions<SqlOptions>(SqlOptions.SectionName);
            services.AddDbContext<FieldsDbContext>(ctx =>
                ctx.UseSqlServer(options.ConnectionString));
                
            services.AddScoped<IFieldRepository, FieldRepository>();
            services.AddScoped<ICultivationHistoryRepository, CultivationHistoryRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<ICultivationHistoryService, CultivationHistoryService>();

            var smtpOtions = configuration.GetOptions<GoogleApiOptions>(GoogleApiOptions.SectionName);
            services.AddSingleton(Options.Create(smtpOtions));

            services.AddScoped<IAddressService, AddressService>();

            services.AddHttpClient<IAddressService, AddressService>((serviceProvider, httpClient) =>
            {
                httpClient.BaseAddress = new Uri($"https://maps.googleapis.com/maps/api/geocode/");
                httpClient.DefaultRequestHeaders.Add("Accept-Language", "pl-PL,pl;q=0.9,en-US;q=0.8,en;q=0.7");
            });

            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblies(typeof(Extensions).Assembly);
            });

            return services;
        }
    }
}
