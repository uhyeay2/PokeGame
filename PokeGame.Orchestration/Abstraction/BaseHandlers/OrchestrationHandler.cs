namespace PokeGame.Orchestration.Abstraction.BaseHandlers
{
    internal abstract class OrchestrationHandler<TRequest> : ITaskHandler<TRequest> where TRequest : IRequest
    {
        protected readonly IOrchestrator _orchestrator;

        public OrchestrationHandler(IOrchestrator orchestrator) => _orchestrator = orchestrator;

        public abstract Task HandleRequestAsync(TRequest request);
    }

    internal abstract class OrchestrationHandler<TRequest, TResponse> : ITaskHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected readonly IOrchestrator _orchestrator;

        public OrchestrationHandler(IOrchestrator orchestrator) => _orchestrator = orchestrator;

        public abstract Task<TResponse> HandleRequestAsync(TRequest request);
    }
}
