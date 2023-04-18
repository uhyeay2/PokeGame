using PokeGame.DataAccess.DataRequests.Users;

namespace PokeGame.Orchestration.Handlers.Users
{
    public class DeleteUserRequest : RequiredGuidRequest
    {
        public DeleteUserRequest() { }

        public DeleteUserRequest(string guid) : base(guid) { }
    }

    internal class DeleteUserHandler : DataHandler<DeleteUserRequest>
    {
        public DeleteUserHandler(IDataAccess dataAccess) : base(dataAccess) { }

        public override async Task HandleRequestAsync(DeleteUserRequest request)
        {
            if(!await _dataAccess.FetchAsync(new IsUserExistingWithGuid(request.Guid)))
            {
                throw new DoesNotExistException(typeof(User), request.Guid, nameof(request.Guid));
            }

            var rowsAffected = await _dataAccess.ExecuteAsync(new DeleteUser(request.Guid));

            if (!rowsAffected.IsAnyRowsUpdated())
            {
                throw new ExpectationFailedException(nameof(DeleteUserRequest));
            }
        }
    }
}
