namespace PokeGame.Orchestration.Abstraction.Interfaces
{
    public interface IHandler { }

    public interface IHandler<TRequest> : IHandler where TRequest : IRequest
    {
        public Task ExecuteAsync(TRequest request);
    }

    public interface IHandler<TRequest, TResponse> : IHandler where TRequest : IRequest<TResponse>
    {
        public Task<TResponse> FetchAsync(TRequest request);
    }
}
