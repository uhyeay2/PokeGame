using PokeGame.DataAccess.DataRequests.Users;

namespace PokeGame.Orchestration.Handlers.Users
{
    public class InsertUserRequest : IRequest, IValidatable
    {
        public string Username { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public bool IsValid(out List<string> validationFailures)
        {
            validationFailures = new List<string>()
                .AddIfNullOrWhiteSpace(Username, nameof(Username))
                .AddIfNullOrWhiteSpace(Email, nameof(Email));

            return !validationFailures.Any();
        }
    }

    internal class InsertUserHandler : DataHandler<InsertUserRequest>
    {
        public InsertUserHandler(IDataAccess dataAccess) : base(dataAccess) { }

        public async override Task ExecuteAsync(InsertUserRequest request)
        {
            var rowsAffected = await _dataAccess.ExecuteAsync(new InsertUser(request.Username, request.Email));
        }
    }
}
