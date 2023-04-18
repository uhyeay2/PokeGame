using PokeGame.DataAccess.DataRequests.Users;

namespace PokeGame.Orchestration.Handlers.Users
{
    public class GetUserByUsernameRequest : RequiredUsernameRequest, IRequest<User>
    {
        public GetUserByUsernameRequest() { }

        public GetUserByUsernameRequest(string username) : base(username) { }
    }

    internal class GetUserByUsernameHandler : DataHandler<GetUserByUsernameRequest, User>
    {
        public GetUserByUsernameHandler(IDataAccess dataAccess) : base(dataAccess) { }

        public override async Task<User> HandleRequestAsync(GetUserByUsernameRequest request)
        {
            var dto = await _dataAccess.FetchAsync(new GetUserByUsername(request.Username));

            return dto != null ? new User(dto.Guid, dto.Username, dto.Email) 
                : throw new DoesNotExistException(typeof(User), request.Username, nameof(request.Username));
        }
    }
}
