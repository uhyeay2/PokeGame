using PokeGame.Domain.Models;

namespace PokeGame.Domain.Interfaces
{
    public interface IHash
    {
        public HashedValue GetHashedValue(string input);
    }
}
