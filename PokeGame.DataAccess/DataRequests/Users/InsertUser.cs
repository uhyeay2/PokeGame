namespace PokeGame.DataAccess.DataRequests.Users
{
    public class InsertUser : IDataRequest
    {
        public InsertUser(string username, string email)
        {
            Username = username;

            Email = email;
        }

        public string Username { get; set; }

        public string Email { get; set; }

        public object? GetParameters() => this;

        public string GetSql() => 
        @"
            IF NOT EXISTS (SELECT * FROM Users WITH(NOLOCK) WHERE Email = @Email OR Username = @Username )
            BEGIN
                INSERT INTO Users (Username, Email) VALUES (@Username, @Email)
            END
        ";
    }
}
