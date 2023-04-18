namespace PokeGame.Orchestration.Abstraction.BaseRequests
{
    public class RequiredGuidHashAndSaltRequest : RequiredGuidRequest
    {
        public byte[] Hash { get; set; } = Array.Empty<byte>();

        public byte[] Salt { get; set; } = Array.Empty<byte>();

        public override bool IsValid(out List<string> validationFailures) => Validation.Initialize(out validationFailures)
            .AddFailureIfEmpty(Guid, nameof(Guid))
            .AddFailureIfNullOrEmpty(Hash, nameof(Hash))
            .AddFailureIfNullOrEmpty(Salt, nameof(Salt))
            .IsValidWhenNoFailures();
    }

    public class RequiredGuidHashAndSaltRequest<TResponse> : RequiredGuidHashAndSaltRequest, IRequest<TResponse> { } 
}
