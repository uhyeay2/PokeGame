using PokeGame.Domain.Exceptions;

namespace PokeGame.Orchestration.Implementation
{
    public class Orchestrator : IOrchestrator
    {
        private readonly IHandlerFactory _handlerFactory;

        public Orchestrator(IHandlerFactory handlerFactory) => _handlerFactory = handlerFactory;

        public async Task<TResponse> FetchResponseAsync<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>
        {
            var handler = _handlerFactory.NewHandler<TRequest, TResponse>();

            Validate(request);

            return await handler.FetchAsync(request);
        }

        public async Task ExecuteRequestAsync<TRequest>(TRequest request) where TRequest : IRequest
        {
            var handler = _handlerFactory.NewHandler<TRequest>();

            Validate(request);

            await handler.ExecuteAsync(request);
        }

        private static void Validate(object request)
        {
            if (request is IValidatable validatable && !validatable.IsValid(out var validationFailures))
            {
                throw new ValidationFailedException(validationFailures);
            }
        }
    }
}
