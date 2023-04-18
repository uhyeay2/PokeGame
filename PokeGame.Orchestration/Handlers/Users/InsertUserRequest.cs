using PokeGame.DataAccess.DataRequests.Users;
using PokeGame.DataAccess.DataRequests.UsersPasswords;

namespace PokeGame.Orchestration.Handlers.Users
{
    public class InsertUserRequest : IRequest<User>, IValidatable
    {
        public InsertUserRequest() { }

        public InsertUserRequest(string email, string username, byte[] passwordHash, byte[] passwordSalt)
        {
            Email = email;
            Username = username;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();

        public bool IsValid(out List<string> validationFailures) => 
            Validation.Initialize(out validationFailures)
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

            if (rowsAffected.IsAnyRowsUpdated())
            {
                var user = await _dataAccess.FetchAsync(new GetUserByUsername(request.Username));

                await _dataAccess.ExecuteAsync(new InsertUserPassword(user.Guid, request.PasswordHash, request.PasswordSalt));

                return new User(user.Guid, user.Username, user.Email);
            }

            var conflicts = new List<(string Name, object Value)>();

            if (await _dataAccess.FetchAsync(new IsEmailTaken(request.Email)))
            {
                conflicts.Add((nameof(request.Email), request.Email));
            }

            if (await _dataAccess.FetchAsync(new IsUsernameTaken(request.Username)))
            {
                conflicts.Add((nameof(request.Username), request.Username));
            }

            throw conflicts.Any() ? new AlreadyExistsException(typeof(User), conflicts) : new ExpectationFailedException(nameof(InsertUserRequest));
        }
    }
}
