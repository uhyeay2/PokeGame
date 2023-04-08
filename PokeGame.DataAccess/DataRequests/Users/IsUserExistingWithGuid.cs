namespace PokeGame.DataAccess.DataRequests.Users
{
    public class IsUserExistingWithGuid : GuidRequest<bool>
    {
        public IsUserExistingWithGuid(Guid guid) : base(guid) { }

        public override string GetSql() => "SELECT CASE WHEN EXISTS (SELECT * FROM Users WITH(NOLOCK) WHERE Guid = @Guid) THEN 1 ELSE 0 END";
    }
}
