using PokeGame.DataAccess.DataRequests.Users;
using PokeGame.DataAccess.DataRequests.UsersPasswords;
using System.Text;

namespace PokeGame.DataAccess.Tests.DataRequestTests.UsersPasswords
{
    public class GetUserPasswordTests : DataRequestTest
    {
        [Fact]
        public async Task GetUserPassword_Given_UserDoesNotExist_Should_ReturnNull() =>
            Assert.Null(await _dataAccess.FetchAsync(new GetUserPassword(_testGuid)));

        [Fact]
        public async Task GetUserPassword_Given_UserPasswordExists_Should_ReturnHashedValuesRecord()
        {
            var user = await _seeder.NewUserAsync();

            var passwordInserted = new InsertUserPassword(user.Guid, Encoding.UTF8.GetBytes("Hash"), Encoding.UTF8.GetBytes("Salt"));

            await _dataAccess.ExecuteAsync(passwordInserted);

            var result = await _dataAccess.FetchAsync(new GetUserPassword(user.Guid));

            await _dataAccess.ExecuteAsync(new DeleteUser(user.Guid));

            Assert.Multiple(() =>
            {
                Assert.NotNull(result);

                Assert.Equal(passwordInserted.Hash, result.Hash);
                Assert.Equal(passwordInserted.Salt, result.Salt);
            });
        }
    }
}
