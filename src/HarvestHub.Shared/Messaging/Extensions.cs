using Microsoft.Extensions.DependencyInjection;

namespace HarvestHub.Shared.Messaging
{
    internal static class Extensions
    {
        private const string SectionName = "messaging";

        public static IServiceCollection AddMessaging(this IServiceCollection services)
        {
            services.AddTransient<IMessageBroker, MassTransitMessageBroker>();

            return services;
        }
    }
}
