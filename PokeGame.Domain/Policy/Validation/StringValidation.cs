using System.Text.RegularExpressions;

namespace PokeGame.Domain.Policy.Validation
{
    public static class StringValidation
    {
        public static List<string> AddFailureIfNullOrWhiteSpace(this List<string> validationFailures, string input, string nameOfInput)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                validationFailures.Add(ValidationMessages.MissingRequiredField(nameOfInput));
            }

            return validationFailures;
        }

        private static readonly Regex _emailFormatRegex = new Regex(@".+@.+\..+");

        public static List<string> AddFailureIfInvalidEmailFormat(this List<string> validationFailures, string input, string nameOfInput)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                validationFailures.Add(ValidationMessages.MissingRequiredField(nameOfInput));
            }
            else if(!_emailFormatRegex.IsMatch(input))
            {
                validationFailures.Add(ValidationMessages.InvalidEmail(nameOfInput));
            }

            return validationFailures;
        }
    }
}
