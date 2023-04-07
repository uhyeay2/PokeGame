namespace PokeGame.DataAccess.DataRequests.UsersPasswords
{
    public class GetUserPassword : GuidRequest<DTO_HashedValue>
    {
        public GetUserPassword(Guid guid) : base(guid) { }

        public override string GetSql() =>
        @"
            SELECT 
                HashedValues.* 
            FROM Users WITH(NOLOCK)
                JOIN UsersPasswords WITH(NOLOCK) ON UsersPasswords.UserId = Users.Id
                    JOIN HashedValues WITH(NOLOCK) ON HashedValues.Id = UsersPasswords.HashedValueId
            WHERE Users.Guid = @Guid
        ";
    }
}
