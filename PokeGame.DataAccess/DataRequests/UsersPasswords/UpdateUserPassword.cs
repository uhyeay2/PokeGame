namespace PokeGame.DataAccess.DataRequests.UsersPasswords
{
    public class UpdateUserPassword : GuidRequest
    {
        public UpdateUserPassword(Guid guid, byte[] hash, byte[] salt) : base(guid) 
        { 
            Hash = hash;
            Salt = salt;
        }

        public byte[] Hash { get; set; }

        public byte[] Salt { get; set; }

        public override object? GetParameters() => new { Guid, Hash, Salt };

        public override string GetSql() =>
        @"
            UPDATE HashedValues SET 
                Hash = @Hash,
                Salt = @Salt
            WHERE Id = ( SELECT UsersPasswords.HashedValueId 
                FROM UsersPasswords WITH(NOLOCK) 
                    JOIN Users WITH(NOLOCK) ON Users.Id = UsersPasswords.UserId )
        ";
    }
}
