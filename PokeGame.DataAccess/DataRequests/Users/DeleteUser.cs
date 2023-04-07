namespace PokeGame.DataAccess.DataRequests.Users
{
    public class DeleteUser : GuidRequest
    {
        public DeleteUser(Guid guid) : base(guid) { }

        public override string GetSql() =>
        @"            
            DECLARE @UserId INT = ( SELECT Id FROM Users WITH(NOLOCK) WHERE Guid = @Guid )

            DECLARE @HashedValueId INT = ( SELECT HashedValueId FROM UsersPasswords WITH(NOLOCK) WHERE UserId = @UserId )

            DELETE FROM UsersPasswords WHERE UserId = @UserId

            DELETE FROM HashedValues WHERE Id = @HashedValueId

            DELETE FROM Users where Id = @UserId
        ";
    }
}
