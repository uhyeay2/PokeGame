namespace PokeGame.Domain.Models
{
    public class User
    {
        public Guid Guid { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
