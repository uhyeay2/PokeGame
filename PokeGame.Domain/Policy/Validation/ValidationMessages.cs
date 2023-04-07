namespace PokeGame.Domain.Policy.Validation
{
    public static class ValidationMessages
    {
        public static string MissingRequiredField(string nameOfRequiredField) => $"{nameOfRequiredField} is a required field!";

        public static string InvalidEmail(string nameOfEmailField) => $"{nameOfEmailField} is not a valid email!";
    }
}
