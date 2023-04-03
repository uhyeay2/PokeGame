namespace PokeGame.Orchestration.Abstraction.BaseRequests
{
    public class RequiredGuidRequest : IValidatable
    {
        public Guid Guid { get; set; }

        public bool IsValid(out List<string> validationFailures)
        {
            validationFailures = new List<string>();

            if (Guid == Guid.Empty)
            {
                validationFailures.Add("Guid is required!");

                return false;
            }

            return true;
        }
    }
}
