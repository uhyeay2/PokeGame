namespace PokeGame.DataAccess.DataTransferObjects
{
    public class DTO_User
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateTime CreatedAtDateTimeUTC { get; set; }
    }
}
