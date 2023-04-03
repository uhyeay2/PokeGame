namespace PokeGame.Orchestration.Abstraction.Interfaces
{
    public interface IOrchestrator
    {
        public Task<TResponse> FetchResponseAsync<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>;

        public Task ExecuteRequestAsync<TRequest>(TRequest request) where TRequest : IRequest;
    }
}
