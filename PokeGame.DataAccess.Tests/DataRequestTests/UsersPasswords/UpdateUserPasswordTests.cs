using PokeGame.DataAccess.DataRequests.Users;
using PokeGame.DataAccess.DataRequests.UsersPasswords;
using System.Text;

namespace PokeGame.DataAccess.Tests.DataRequestTests.UsersPasswords
{
    public class UpdateUserPasswordTests : DataRequestTest
    {
        [Fact]
        public async Task UpdateUserPassword_Given_UserDoesNotExist_Should_ReturnZero_RowsAffected() =>
            Assert.Equal(0, await _dataAccess.ExecuteAsync(new UpdateUserPassword(_testGuid, _testBytes, _testBytes)));

        [Fact]
        public async Task UpdateUserPassword_Given_UserExistsButNoPassword_Should_ReturnZero_RowsAffected()
        {
            var user = await _seeder.NewUserAsync();

            var result = await _dataAccess.ExecuteAsync(new UpdateUserPassword(user.Guid, _testBytes, _testBytes));

            await _dataAccess.ExecuteAsync(new DeleteUser(user.Guid));

            Assert.Equal(0, result);
        }

        [Fact]
        public async Task UpdateUserPassword_Given_PasswordUpdated_Should_ReturnOne_RowsAffected()
        {
            var user = await _seeder.NewUserAsync();

            await _dataAccess.ExecuteAsync(new InsertUserPassword(user.Guid, _testBytes, _testBytes));

            var expectedHash = Encoding.UTF8.GetBytes("Hash");
            var expectedSalt = Encoding.UTF8.GetBytes("Salt");

            var rowsAffected = await _dataAccess.ExecuteAsync(new UpdateUserPassword(user.Guid, expectedHash, expectedSalt));

            var updatedRecord = await _dataAccess.FetchAsync(new GetUserPassword(user.Guid));

            await _dataAccess.ExecuteAsync(new DeleteUser(user.Guid));

            Assert.Multiple(() =>
            {
                Assert.Equal(1, rowsAffected);

                Assert.NotNull(updatedRecord);

                Assert.Equal(expectedHash, updatedRecord.Hash);

                Assert.Equal(expectedSalt, updatedRecord.Salt);
            });
        }
    }
}
