using Microsoft.Extensions.DependencyInjection;
using PokeGame.DataAccess.Implementation;
using PokeGame.Utilities;

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

            services.InjectUtilities();

            services.AddTransient<IOrchestrator, Orchestrator>();

            services.AddTransient<IHandlerFactory>(_ => new HandlerFactory(services, GetHandlers()));

            return services;
        }
       
        static IEnumerable<Type> GetHandlers() => typeof(DependencyInjection).Assembly.GetTypes().Where(x => typeof(IHandler).IsAssignableFrom(x) && x.IsClass);
    }
}
