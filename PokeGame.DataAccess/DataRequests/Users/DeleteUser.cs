namespace PokeGame.DataAccess.DataRequests.Users
{
    public class DeleteUser : IDataRequest
    {
        public DeleteUser(Guid guid) => Guid = guid;

        public Guid Guid { get; set; }

        public object? GetParameters() => this;

        public string GetSql() => "DELETE FROM Users WHERE Guid = @Guid";
    }
}
