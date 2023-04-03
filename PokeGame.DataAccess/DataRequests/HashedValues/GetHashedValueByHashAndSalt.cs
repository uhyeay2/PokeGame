namespace PokeGame.DataAccess.DataRequests.HashedValues
{
    public class GetHashedValueByHashAndSalt : IDataRequest<DTO_HashedValue>
    {
        public GetHashedValueByHashAndSalt(string hash, string salt)
        {
            Hash = hash;
            Salt = salt;
        }

        public string Hash { get; set; }

        public string Salt { get; set; }

        public object? GetParameters() => this;

        public string GetSql() => "SELECT * FROM HashedValues WITH(NOLOCK) WHERE Hash = @Hash and Salt = @Salt";
    }
}
