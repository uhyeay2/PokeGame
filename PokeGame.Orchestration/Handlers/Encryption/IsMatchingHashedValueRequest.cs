namespace PokeGame.Orchestration.Handlers.Encryption
{
    public class IsMatchingHashedValueRequest : RequiredStringInputRequest, IRequest<bool>
    {
        public HashedValue HashedValue { get; set; } = new HashedValue();

        public override bool IsValid(out List<string> validationFailures) => Validation.Start(out validationFailures)
            .AddFailureIfNullOrEmpty(HashedValue.Hash, nameof(HashedValue.Hash))
            .AddFailureIfNullOrEmpty(HashedValue.Salt, nameof(HashedValue.Salt))
            .AddFailureIfNullOrWhiteSpace(Input, nameof(Input))
            .IsValidWhenNoFailures();
    }

    internal class IsMatchingHashedValueHandler : IHandler<IsMatchingHashedValueRequest, bool>
    {
        private readonly IHashComparer _hashComparer;

        public IsMatchingHashedValueHandler(IHashComparer hashComparer) => _hashComparer = hashComparer;

        public bool HandleRequest(IsMatchingHashedValueRequest request) =>
            _hashComparer.IsMatchingHashedValue(request.Input, request.HashedValue);
    }
}
