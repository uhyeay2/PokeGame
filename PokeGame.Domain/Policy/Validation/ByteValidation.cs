namespace PokeGame.Domain.Policy.Validation
{
    public static class ByteValidation
    {
        public static List<string> AddFailureIfNullOrEmpty(this List<string> validationFailures, byte[]? bytes, string nameOfRequiredCollection)
        {
            if (bytes == null || !bytes.Any())
            {
                validationFailures.Add(ValidationMessages.MissingRequiredField(nameOfRequiredCollection));
            }

            return validationFailures;
        }
    }
}
