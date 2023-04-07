namespace PokeGame.DataAccess.DataTransferObjects
{
    public class DTO_HashedValue
    {
        public int Id { get; set; }

        public byte[] Hash { get; set; } = null!;

        public byte[] Salt { get; set; } = null!;
    }
}
