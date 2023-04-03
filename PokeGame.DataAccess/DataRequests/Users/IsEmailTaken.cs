namespace PokeGame.DataAccess.DataRequests.Users
{
    public class IsEmailTaken : IDataRequest<bool>
    {
        public IsEmailTaken(string email) => Email = email;

        public string Email { get; set; }

        public object? GetParameters() => this;

        public string GetSql() => "SELECT CASE WHEN EXISTS (SELECT * FROM Users WITH(NOLOCK) WHERE Email = @Email) THEN 1 ELSE 0 END";
    }
}
