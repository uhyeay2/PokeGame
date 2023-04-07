namespace PokeGame.DataAccess.DataRequests.HashedValues
{
    public class GetHashedValueByHashAndSalt : IDataRequest<DTO_HashedValue>
    {
        public GetHashedValueByHashAndSalt(byte[] hash, byte[] salt)
        {
            Hash = hash;
            Salt = salt;
        }

        public byte[] Hash { get; set; }

        public byte[] Salt { get; set; }

        public object? GetParameters() => this;

        public string GetSql() => "SELECT * FROM HashedValues WITH(NOLOCK) WHERE Hash = @Hash and Salt = @Salt";
    }
}
