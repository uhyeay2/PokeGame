namespace PokeGame.Domain.Models
{
    public class HashedValue
    {
        public HashedValue() { }

        public HashedValue(string hash, string salt)
        {
            Hash = hash;
            Salt = salt;
        }

        public string Hash { get; set; } = string.Empty;

        public string Salt { get; set; } = string.Empty;
    }
}
