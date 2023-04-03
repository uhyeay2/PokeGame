namespace PokeGame.DataAccess.DataTransferObjects
{
    public class DTO_HashedValue
    {
        public int Id { get; set; }

        public string Hash { get; set; } = null!;

        public string Salt { get; set; } = null!;
    }
}
