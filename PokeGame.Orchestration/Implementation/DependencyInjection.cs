using Microsoft.Extensions.DependencyInjection;
using PokeGame.DataAccess.Implementation;

namespace PokeGame.Orchestration.Implementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectOrchestration(this IServiceCollection services, string connectionString)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.InjectDataAccess(connectionString);

            services.AddSingleton<IHandlerFactory>(new HandlerFactory(services, GetHandlers()));

            services.AddScoped<IOrchestrator, Orchestrator>();

            return services;
        }

        static IEnumerable<Type> GetHandlers() => typeof(DependencyInjection).Assembly.GetTypes().Where(x => typeof(IHandler).IsAssignableFrom(x) && x.IsClass);
    }
}
