namespace PokeGame.Orchestration.Abstraction.Interfaces
{
    public interface IHandlerFactory
    {
        public IHandler<TRequest, TResponse> NewHandler<TRequest, TResponse>() where TRequest : IRequest<TResponse>;

        public IHandler<TRequest> NewHandler<TRequest>() where TRequest : IRequest;
    }
}
