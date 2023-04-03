using PokeGame.DataAccess.DataRequests.Users;
using PokeGame.Orchestration.Abstraction.BaseRequests;

namespace PokeGame.Orchestration.Handlers.Users
{
    public class IsUsernameTakenRequest : RequiredUsernameRequest, IRequest<bool> { }

    internal class IsUsernameTakenHandler : DataHandler<IsUsernameTakenRequest, bool>
    {
        public IsUsernameTakenHandler(IDataAccess dataAccess) : base(dataAccess) { }

        public override async Task<bool> FetchAsync(IsUsernameTakenRequest request) => 
            await _dataAccess.FetchAsync(new IsUsernameTaken(request.Username));
    }
}
