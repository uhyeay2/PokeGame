namespace PokeGame.DataAccess.DataRequests.UsersPasswords
{
    public class InsertUserPassword : GuidRequest
    {
        public InsertUserPassword(Guid userGuid, byte[] hash, byte[] salt) : base(userGuid)
        {
            Hash = hash;
            Salt = salt;
        }

        public byte[] Hash { get; set; }

        public byte[] Salt { get; set; }

        public override object? GetParameters() => new { Guid, Hash, Salt };

        public override string GetSql() =>
        @"
            DECLARE @UserId INT = ( SELECT Id FROM Users WITH(NOLOCK) WHERE Guid = @Guid )

            IF @UserId IS NOT NULL AND NOT EXISTS ( SELECT * FROM UsersPasswords WITH(NOLOCK) WHERE UserId = @UserId )
            BEGIN
                INSERT INTO HashedValues (Hash, Salt) VALUES (@Hash, @Salt)

                DECLARE @HashedValueId INT = ( SELECT SCOPE_IDENTITY() )

                INSERT INTO UsersPasswords (UserId, HashedValueId) VALUES (@UserId, @HashedValueId)
            END
        ";
    }
}
