namespace PokeGame.DataAccess.DataRequests.HashedValues
{
    public class InsertHashedValue : IDataRequest
    {
        public InsertHashedValue(string hash, string salt)
        {
            Hash = hash;
            Salt = salt;
        }

        public string Hash { get; set; }

        public string Salt { get; set; }

        public object? GetParameters() => this;

        public string GetSql() => "INSERT INTO HashedValues (Hash, Salt) VALUES (@Hash, @Salt)";
    }
}
