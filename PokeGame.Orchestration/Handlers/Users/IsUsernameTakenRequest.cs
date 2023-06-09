﻿using PokeGame.DataAccess.DataRequests.Users;

namespace PokeGame.Orchestration.Handlers.Users
{
    public class IsUsernameTakenRequest : RequiredUsernameRequest, IRequest<bool> { }

    internal class IsUsernameTakenHandler : DataHandler<IsUsernameTakenRequest, bool>
    {
        public IsUsernameTakenHandler(IDataAccess dataAccess) : base(dataAccess) { }

        public override async Task<bool> HandleRequestAsync(IsUsernameTakenRequest request) => 
            await _dataAccess.FetchAsync(new IsUsernameTaken(request.Username));
    }
}
