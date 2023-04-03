using Microsoft.Extensions.DependencyInjection;

namespace PokeGame.Orchestration.Implementation
{
    internal class HandlerFactory : IHandlerFactory
    {
        private readonly IEnumerable<Type> _handlers;

        private readonly IServiceProvider _serviceProvider;

        public HandlerFactory(IServiceCollection services, IEnumerable<Type> handlers)
        {
            _serviceProvider = services.BuildServiceProvider();

            _handlers = handlers;
        }

        public IHandler<TRequest> NewHandler<TRequest>() where TRequest : IRequest
        {
            var handler = _handlers.FirstOrDefault(_ => _.IsAssignableTo(typeof(IHandler<TRequest>)));

            if (handler == null)
            {
                throw new ArgumentNullException("No handler found for Request Type: " + nameof(TRequest));
            }

            return (IHandler<TRequest>)ActivatorUtilities.CreateInstance(_serviceProvider, handler);
        }

        public IHandler<TRequest, TResponse> NewHandler<TRequest, TResponse>() where TRequest : IRequest<TResponse>
        {
            var handler = _handlers.FirstOrDefault(_ => _.IsAssignableTo(typeof(IHandler<TRequest, TResponse>)));

            if (handler == null)
            {
                throw new ArgumentNullException("No handler found for Request Type: " + nameof(TRequest));
            }

            return (IHandler<TRequest, TResponse>)ActivatorUtilities.CreateInstance(_serviceProvider, handler);
        }
    }
}
