using PokeGame.DataAccess.DataRequests.Users;

namespace PokeGame.Orchestration.Handlers.Users
{
    public class IsEmailTakenRequest : IRequest<bool>, IValidatable
    {
        public string Email { get; set; } = string.Empty;

        public bool IsValid(out List<string> validationFailures) => Validation.Initialize(out validationFailures)
            .AddFailureIfInvalidEmailFormat(Email, nameof(Email))
            .IsValidWhenNoFailures();
    }

    internal class IsEmailTakenHandler : DataHandler<IsEmailTakenRequest, bool>
    {
        public IsEmailTakenHandler(IDataAccess dataAccess) : base(dataAccess) { }

        public override async Task<bool> HandleRequestAsync(IsEmailTakenRequest request) =>
            await _dataAccess.FetchAsync(new IsEmailTaken(request.Email));
    }
}
