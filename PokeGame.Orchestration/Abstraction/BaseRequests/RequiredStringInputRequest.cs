namespace PokeGame.Orchestration.Abstraction.BaseRequests
{
    public class RequiredStringInputRequest : IValidatable
    {
        public string Input { get; set; } = string.Empty;

        public virtual bool IsValid(out List<string> validationFailures) => Validation.Initialize(out validationFailures)
            .AddFailureIfNullOrWhiteSpace(Input, nameof(Input))
            .IsValidWhenNoFailures();
    }
}
