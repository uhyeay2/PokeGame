namespace PokeGame.Domain.Policy.Validation
{
    public static class GuidValidation
    {
        public static List<string> AddFailureIfEmpty(this List<string> validationFailures, Guid input, string nameOfInput)
        {
            if (input == Guid.Empty)
            {
                validationFailures.Add(ValidationMessages.MissingRequiredField(nameOfInput));
            }

            return validationFailures;
        }
    }
}
