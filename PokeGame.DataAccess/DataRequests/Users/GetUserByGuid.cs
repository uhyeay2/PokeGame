namespace PokeGame.DataAccess.DataRequests.Users
{
    public class GetUserByGuid : GuidRequest<DTO_User>
    {
        public GetUserByGuid(Guid guid) : base(guid) { }

        public override string GetSql() => "SELECT * FROM Users WITH(NOLOCK) WHERE Guid = @Guid";
    }
}
