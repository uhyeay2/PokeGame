namespace PokeGame.Orchestration.Abstraction.BaseRequests
{
    public abstract class RequiredUsernameRequest : IValidatable
    {
        public string Username { get; set; } = string.Empty;

        public bool IsValid(out List<string> validationFailures)
        {
            validationFailures = new List<string>()
                .AddIfNullOrWhiteSpace(Username, nameof(Username));

            return !validationFailures.Any();
        }
    }
}
