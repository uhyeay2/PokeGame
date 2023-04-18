namespace PokeGame.Orchestration.Abstraction.BaseRequests
{
    public class RequiredGuidRequest : IRequest, IValidatable
    {
        public RequiredGuidRequest() { }

        public RequiredGuidRequest(Guid guid) => Guid = guid;

        public RequiredGuidRequest(string guid) => Guid = Guid.TryParse(guid, out var g) ? g : Guid.Empty;

        public Guid Guid { get; set; }

        public virtual bool IsValid(out List<string> validationFailures)
        {
            validationFailures = new List<string>();

            if (Guid == Guid.Empty)
            {
                validationFailures.Add(ValidationMessages.MissingRequiredField(nameof(Guid)));

                return false;
            }

            return true;
        }
    }

    public class RequiredGuidRequest<TResponse> : RequiredGuidRequest, IRequest<TResponse>
    {
        public RequiredGuidRequest() { }

        public RequiredGuidRequest(Guid guid) : base(guid) { }

        public RequiredGuidRequest(string guid) : base(guid) { }
    }
}
