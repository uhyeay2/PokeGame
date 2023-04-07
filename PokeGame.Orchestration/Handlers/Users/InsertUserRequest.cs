using PokeGame.DataAccess.DataRequests.Users;
using PokeGame.DataAccess.DataRequests.UsersPasswords;

namespace PokeGame.Orchestration.Handlers.Users
{
    public class InsertUserRequest : IRequest<User>, IValidatable
    {
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();

        public bool IsValid(out List<string> validationFailures) => Validation.Start(out validationFailures)
            .AddFailureIfInvalidEmailFormat(Email, nameof(Email))
            .AddFailureIfNullOrWhiteSpace(Username, nameof(Username))
            .AddFailureIfNullOrEmpty(PasswordHash, nameof(PasswordHash))
            .AddFailureIfNullOrEmpty(PasswordSalt, nameof(PasswordSalt))
            .IsValidWhenNoFailures();
    }

    internal class InsertUserHandler : DataHandler<InsertUserRequest, User>
    {
        public InsertUserHandler(IDataAccess dataAccess) : base(dataAccess) { }

        public async override Task<User> HandleRequestAsync(InsertUserRequest request)
        {
            var rowsAffected = await _dataAccess.ExecuteAsync(new InsertUser(request.Username, request.Email));

            if(!rowsAffected.IsAnyRowsUpdated())
            {
                await HandleFailure(request);
            }

            var user = await _dataAccess.FetchAsync(new GetUserByUsername(request.Username));

            await _dataAccess.ExecuteAsync(new InsertUserPassword(user.Guid, request.PasswordHash, request.PasswordSalt));

            return new User(user.Guid, user.Username, user.Email);
        }

        private async Task HandleFailure(InsertUserRequest request)
        {
            var failureReasons = new List<string>();

            if (await _dataAccess.FetchAsync(new IsEmailTaken(request.Email)))
            {
                failureReasons.Add($"User already exists with Email: {request.Email}");
            }

            if (await _dataAccess.FetchAsync(new IsUsernameTaken(request.Username)))
            {
                failureReasons.Add($"User already exists with Username: {request.Username}");
            }

            if (failureReasons.Any())
            {
                throw new AlreadyExistsException(failureReasons);
            }

            throw new ExpectationFailedException("InsertUser Failed Unexpectedly");
        }
    }
}
