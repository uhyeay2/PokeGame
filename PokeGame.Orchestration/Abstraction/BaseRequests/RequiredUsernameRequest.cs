namespace PokeGame.Orchestration.Abstraction.BaseRequests
{
    public abstract class RequiredUsernameRequest : IValidatable
    {
        public RequiredUsernameRequest() { }

        public RequiredUsernameRequest(string username) => Username = username;

        public string Username { get; set; } = string.Empty;

        public bool IsValid(out List<string> validationFailures) => Validation.Initialize(out validationFailures)
            .AddFailureIfNullOrWhiteSpace(Username, nameof(Username))
            .IsValidWhenNoFailures();
    }
}
