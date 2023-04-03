namespace PokeGame.DataAccess.DataRequests.Users
{
    public class IsUsernameTaken : IDataRequest<bool>
    {
        public IsUsernameTaken(string username) => Username = username;

        public string Username { get; set; }

        public object? GetParameters() => this;

        public string GetSql() => "SELECT CASE WHEN EXISTS (SELECT * FROM Users WITH(NOLOCK) WHERE Username = @Username) THEN 1 ELSE 0 END";
    }
}
