using PokeGame.DataAccess.DataRequests.Users;

namespace PokeGame.DataAccess.Tests.DataRequestTests.Users
{
    public class IsUsernameTakenTests : DataRequestTest
    {
        [Fact]
        public async Task IsUsernameTaken_Given_UsernameNotTaken_Should_ReturnFalse() => 
            Assert.False(await _dataAccess.FetchAsync(new IsUsernameTaken("UsernameNotExisting")));

        [Fact]
        public async Task IsUsernameTaken_Given_UsernameIsTaken_Should_ReturnTrue()
        {
            var user = await _seeder.NewUserAsync();

            var exists = await _dataAccess.FetchAsync(new IsUsernameTaken(user.Username));

            await _dataAccess.ExecuteAsync(new DeleteUser(user.Guid));

            Assert.True(exists);
        }
    }
}
