namespace PokeGame.Domain.Policy.Validation
{
    public static class IntValidation
    {
        public static bool IsAnyRowsUpdated(this int rowsAffected) => rowsAffected > 0;
    }
}
