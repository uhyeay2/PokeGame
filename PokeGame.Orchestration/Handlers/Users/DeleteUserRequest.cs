using PokeGame.DataAccess.DataRequests.Users;
using PokeGame.Orchestration.Abstraction.BaseRequests;

namespace PokeGame.Orchestration.Handlers.Users
{
    public class DeleteUserRequest :RequiredGuidRequest, IRequest { }

    internal class DeleteUserHandler : DataHandler<DeleteUserRequest>
    {
        public DeleteUserHandler(IDataAccess dataAccess) : base(dataAccess) { }

        public override async Task ExecuteAsync(DeleteUserRequest request) =>
            await _dataAccess.ExecuteAsync(new DeleteUser(request.Guid));
    }
}
