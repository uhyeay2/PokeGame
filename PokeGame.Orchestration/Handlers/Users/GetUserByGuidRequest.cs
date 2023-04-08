using PokeGame.DataAccess.DataRequests.Users;

namespace PokeGame.Orchestration.Handlers.Users
{
    public class GetUserByGuidRequest : RequiredGuidRequest<User>
    {
        public GetUserByGuidRequest(Guid guid) => Guid = guid;

        public GetUserByGuidRequest() { }
    }

    internal class GetUSerByGuidHandler : DataHandler<GetUserByGuidRequest, User>
    {
        public GetUSerByGuidHandler(IDataAccess dataAccess) : base(dataAccess) { }

        public override async Task<User> HandleRequestAsync(GetUserByGuidRequest request)
        {
            var user = await _dataAccess.FetchAsync(new GetUserByGuid(request.Guid));

            return user != null ? new User(user.Guid, user.Username, user.Email)
                : throw new DoesNotExistException(typeof(User), request.Guid, nameof(request.Guid));
        }
    }
}
