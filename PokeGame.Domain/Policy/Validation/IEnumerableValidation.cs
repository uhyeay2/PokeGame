namespace PokeGame.Domain.Policy.Validation
{
    public static class IEnumerableValidation
    {
        public static List<string> AddFailureIfNullOrEmpty<T>(this List<string> validationFailures, IEnumerable<T>? collection, string nameOfRequiredCollection)
        {
            if (collection == null || !collection.Any())
            {
                validationFailures.Add(ValidationMessages.MissingRequiredField(nameOfRequiredCollection));
            }

            return validationFailures;
        }
    }
}
