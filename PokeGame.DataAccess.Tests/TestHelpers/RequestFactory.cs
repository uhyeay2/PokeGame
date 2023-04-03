using PokeGame.DataAccess.DataRequests.HashedValues;

namespace PokeGame.DataAccess.Tests.TestHelpers
{
    public class RequestFactory
    {
        public InsertHashedValue InsertHashedValue(string? hash = null, string? salt = null) => new (hash?? Guid.NewGuid().ToString(), salt ?? Guid.NewGuid().ToString());
    }
}
