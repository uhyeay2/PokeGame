using PokeGame.DataAccess.DataRequests.Users;
using PokeGame.Orchestration.Abstraction.BaseRequests;

namespace PokeGame.Orchestration.Handlers.Users
{
    public class GetUserByUsernameRequest : RequiredUsernameRequest, IRequest<User> { }

    internal class GetUserByUsernameHandler : DataHandler<GetUserByUsernameRequest, User>
    {
        public GetUserByUsernameHandler(IDataAccess dataAccess) : base(dataAccess) { }

        public override async Task<User> HandleRequestAsync(GetUserByUsernameRequest request)
        {
            var dto = await _dataAccess.FetchAsync(new GetUserByUsername(request.Username));

            return new User()
            {
                Username = dto.Username,
                Email = dto.Email,
                Guid = dto.Guid
            };
        }
    }
}
