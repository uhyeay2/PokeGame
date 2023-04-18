using PokeGame.Orchestration.Handlers.Encryption;

namespace PokeGame.Orchestration.Handlers.UsersPasswords
{
    public class IsMatchingUserPasswordRequest : RequiredGuidAndPasswordRequest<bool> 
    {
        public IsMatchingUserPasswordRequest() { }

        public IsMatchingUserPasswordRequest(Guid guid, string password) : base(guid, password) { } 
    }

    internal class IsMatchingUserPasswordHandler : OrchestrationHandler<IsMatchingUserPasswordRequest, bool>
    {
        public IsMatchingUserPasswordHandler(IOrchestrator orchestrator) : base(orchestrator) { }

        public override async Task<bool> HandleRequestAsync(IsMatchingUserPasswordRequest request)
        {
            var password = await _orchestrator.GetResponseAsync<GetUserPasswordRequest, HashedValue>(new(request.Guid));

            return _orchestrator.GetResponse<IsMatchingHashedValueRequest, bool>(new (request.Password, password));
        }
    }
}
