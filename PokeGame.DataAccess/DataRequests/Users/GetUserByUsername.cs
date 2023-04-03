namespace PokeGame.DataAccess.DataRequests.Users
{
    public class GetUserByUsername : IDataRequest<DTO_User>
    {
        public GetUserByUsername(string username) => Username = username;

        public string Username { get; set; }

        public object? GetParameters() => this;

        public string GetSql() => "SELECT * FROM Users WITH(NOLOCK) WHERE Username = @Username";
    }
}
