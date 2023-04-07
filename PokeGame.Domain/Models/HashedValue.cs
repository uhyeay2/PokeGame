namespace PokeGame.Domain.Models
{
    public class HashedValue
    {
        public HashedValue() { }

        public HashedValue(byte[] hash, byte[] salt)
        {
            Hash = hash;
            Salt = salt;
        }

        public byte[] Hash { get; set; } = Array.Empty<byte>();

        public byte[] Salt { get; set; } = Array.Empty<byte>();
    }
}
