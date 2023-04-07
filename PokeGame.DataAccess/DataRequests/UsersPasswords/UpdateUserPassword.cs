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

        public override string GetSql()
        {
            throw new NotImplementedException();
        }
    }
}
