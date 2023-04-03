using PokeGame.DataAccess.Abstraction;
using PokeGame.Orchestration.Abstraction.Interfaces;

namespace PokeGame.Orchestration.Abstraction.BaseHandlers
{
    internal abstract class DataHandler<TRequest> : IHandler<TRequest> where TRequest : IRequest
    {
        protected readonly IDataAccess _dataAccess;

        public DataHandler(IDataAccess dataAccess) => _dataAccess = dataAccess;

        public abstract Task ExecuteAsync(TRequest request);
    }

    internal abstract class DataHandler<TRequest, TResponse> : IHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected readonly IDataAccess _dataAccess;

        public DataHandler(IDataAccess dataAccess) => _dataAccess = dataAccess;

        public abstract Task<TResponse> FetchAsync(TRequest request);
    }
}
