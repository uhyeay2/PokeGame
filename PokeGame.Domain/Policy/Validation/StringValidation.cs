namespace PokeGame.Domain.Policy.Validation
{
    public static class StringValidation
    {
        public static List<string> AddIfNullOrWhiteSpace(this List<string> validationFailures, string input, string nameOfInput)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                validationFailures.Add($"{nameOfInput} is required!");
            }

            return validationFailures;
        }
    }
}
