namespace PokeGame.Domain.Models
{
    public class User
    {
        public User() { }

        public User(Guid guid, string username, string email)
        {
            Guid = guid;
            Username = username;
            Email = email;
        }

        public Guid Guid { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
