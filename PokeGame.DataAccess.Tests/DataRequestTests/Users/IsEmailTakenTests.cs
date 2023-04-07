using PokeGame.DataAccess.DataRequests.Users;

namespace PokeGame.DataAccess.Tests.DataRequestTests.Users
{
    public class IsEmailTakenTests : DataRequestTest
    {
        [Fact]
        public async Task IsEmailTaken_Given_EmailNotTaken_Should_ReturnFalse() =>
            Assert.False(await _dataAccess.FetchAsync(new IsEmailTaken("EmailNotExisting")));

        [Fact]
        public async Task IsEmailTaken_Given_EmailIsTaken_Should_ReturnTrue()
        {
            var user = await _seeder.NewUserAsync();

            var exists = await _dataAccess.FetchAsync(new IsEmailTaken(user.Email));

            await _dataAccess.ExecuteAsync(new DeleteUser(user.Guid));

            Assert.True(exists);
        }
    }
}
