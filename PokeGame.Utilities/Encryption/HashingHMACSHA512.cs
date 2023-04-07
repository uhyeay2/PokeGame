using PokeGame.Domain.Interfaces;
using PokeGame.Domain.Models;
using System.Security.Cryptography;
using System.Text;

namespace PokeGame.Utilities.Encryption
{
    internal class HashingHMACSHA512 : IHash, IHashComparer
    {
        private static byte[] GetBytes(string input) => Encoding.UTF8.GetBytes(input);

        public HashedValue GetHashedValue(string input)
        {
            using var hmac = new HMACSHA512();

            var hash = hmac.ComputeHash(GetBytes(input));

            var salt = hmac.Key;

            return new HashedValue(hash, salt);
        }

        public bool IsMatchingHashedValue(string input, HashedValue value)
        {
            using var hmac = new HMACSHA512(value.Salt);
            
            var computedHash = hmac.ComputeHash(GetBytes(input));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != value.Hash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
