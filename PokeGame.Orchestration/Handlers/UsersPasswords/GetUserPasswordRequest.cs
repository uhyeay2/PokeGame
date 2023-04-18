using PokeGame.DataAccess.DataRequests.UsersPasswords;

namespace PokeGame.Orchestration.Handlers.UsersPasswords
{
    public class GetUserPasswordRequest : RequiredGuidRequest<HashedValue>
    {
        public GetUserPasswordRequest() { }

        public GetUserPasswordRequest(Guid guid) : base(guid) { }
    }

    internal class GetUserPasswordHandler : DataHandler<GetUserPasswordRequest, HashedValue>
    {
        public GetUserPasswordHandler(IDataAccess dataAccess) : base(dataAccess) { }

        public async override Task<HashedValue> HandleRequestAsync(GetUserPasswordRequest request)
        {
            var userPassword = await _dataAccess.FetchAsync(new GetUserPassword(request.Guid));

            return userPassword != null ? new HashedValue(userPassword.Hash, userPassword.Salt)
                : throw new DoesNotExistException(typeof(User), request.Guid, nameof(request.Guid));
        }
    }
}
