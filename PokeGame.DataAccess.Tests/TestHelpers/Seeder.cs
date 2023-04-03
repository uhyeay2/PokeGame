using PokeGame.DataAccess.Abstraction;
using PokeGame.DataAccess.DataRequests.Users;
using PokeGame.DataAccess.DataTransferObjects;

namespace PokeGame.DataAccess.Tests.TestHelpers
{
    public class Seeder
    {
        private readonly IDataAccess _dataAccess;

        private readonly Guid _testGuid;

        public Seeder(IDataAccess dataAccess, Guid testGuid)
        {
            _dataAccess = dataAccess;
            _testGuid = testGuid;
        }

        public async Task<DTO_User> NewUserAsync(string? username = null, string? email = null)
        {
            username ??= _testGuid.ToString();
            email ??= _testGuid.ToString();

            await _dataAccess.ExecuteAsync(new InsertUser(username, email));

            return await _dataAccess.FetchAsync(new GetUserByUsername(username));
        }
    }
}
