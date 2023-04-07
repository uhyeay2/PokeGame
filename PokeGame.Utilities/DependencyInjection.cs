using Microsoft.Extensions.DependencyInjection;
using PokeGame.Domain.Interfaces;
using PokeGame.Utilities.Encryption;

namespace PokeGame.Utilities
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectUtilities(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            var hashingService = new HashingHMACSHA512();

            services.AddSingleton<IHash>(hashingService);
            services.AddSingleton<IHashComparer>(hashingService);

            return services;
        }
    }
}
