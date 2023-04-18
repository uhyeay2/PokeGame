namespace PokeGame.Orchestration.Abstraction.BaseRequests
{
    public class RequiredGuidAndPasswordRequest : RequiredGuidRequest
    {
        public RequiredGuidAndPasswordRequest() { }

        public RequiredGuidAndPasswordRequest(Guid guid, string password) : base(guid) => Password = password;

        public string Password { get; set; } = string.Empty;

        public override bool IsValid(out List<string> validationFailures) => Validation.Initialize(out validationFailures)
            .AddFailureIfEmpty(Guid, nameof(Guid))
            .AddFailureIfNullOrWhiteSpace(Password, nameof(Password))
            .IsValidWhenNoFailures();
    }

    public class RequiredGuidAndPasswordRequest<TResponse> : RequiredGuidAndPasswordRequest, IRequest<TResponse>
    {
        public RequiredGuidAndPasswordRequest() { }

        public RequiredGuidAndPasswordRequest(Guid guid, string password) : base(guid, password) { }
    }
}
