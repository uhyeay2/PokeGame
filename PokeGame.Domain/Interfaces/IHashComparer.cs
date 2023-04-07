using PokeGame.Domain.Models;

namespace PokeGame.Domain.Interfaces
{
    public interface IHashComparer
    {
        public bool IsMatchingHashedValue(string input, HashedValue value);
    }
}
