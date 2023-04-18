using PokeGame.DataAccess.DataRequests.Users;
using PokeGame.DataAccess.DataRequests.UsersPasswords;

namespace PokeGame.Orchestration.Handlers.UsersPasswords
{
    public class InsertUserPasswordRequest : RequiredGuidHashAndSaltRequest { }

    internal class InsertUserPasswordHandler : DataHandler<InsertUserPasswordRequest>
    {
        public InsertUserPasswordHandler(IDataAccess dataAccess) : base(dataAccess) { }

        public override async Task HandleRequestAsync(InsertUserPasswordRequest request)
        {
            var rowsAffected = await _dataAccess.ExecuteAsync(new InsertUserPassword(request.Guid, request.Hash, request.Salt));

            if (rowsAffected.IsAnyRowsUpdated())
            {
                return;
            }

            if (!await _dataAccess.FetchAsync(new IsUserExistingWithGuid(request.Guid)))
            {
                throw new DoesNotExistException(typeof(User), request.Guid, nameof(request.Guid));
            }

            throw new ExpectationFailedException(nameof(InsertUserPasswordRequest));
        }
    }
}
