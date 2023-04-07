using PokeGame.DataAccess.DataRequests.Users;

namespace PokeGame.DataAccess.Tests.DataRequestTests.Users
{
    public class InsertUserTests : DataRequestTest
    {
        [Fact]
        public async Task InsertUser_Given_UserIsInserted_Should_ReturnOne_RowAffected()
        {
            var userToInsert = new InsertUser(username: _testGuid.ToString(), email: _testGuid.ToString());

            var rowsAffected = await _dataAccess.ExecuteAsync(userToInsert);

            var recordInserted = await _dataAccess.FetchAsync(new GetUserByUsername(userToInsert.Username));

            await _dataAccess.ExecuteAsync(new DeleteUser(recordInserted.Guid));

            Assert.Multiple(() =>
            {
                Assert.Equal(1, rowsAffected);

                Assert.NotNull(recordInserted);
            });
        }

        [Fact]
        public async Task InsertUser_Given_UsernameAlreadyTaken_Should_ReturnNegativeOne_RowsAffected()
        {
            var userToInsert = new InsertUser(username: _testGuid.ToString(), email: _testGuid.ToString());

            await _dataAccess.ExecuteAsync(userToInsert);

            userToInsert.Email = "New Email That Is Not Existing Already";

            var rowsAffected = await _dataAccess.ExecuteAsync(userToInsert);

            var recordInserted = await _dataAccess.FetchAsync(new GetUserByUsername(userToInsert.Username));
            await _dataAccess.ExecuteAsync(new DeleteUser(recordInserted.Guid));

            Assert.Equal(-1, rowsAffected);
        }

        [Fact]
        public async Task InsertUser_Given_EmailAlreadyTaken_Should_ReturnNegativeOne_RowsAffected()
        {
            var userToInsert = new InsertUser(username: _testGuid.ToString(), email: _testGuid.ToString());

            await _dataAccess.ExecuteAsync(userToInsert);

            userToInsert.Username = "New Username That Is Not Existing Already";

            var rowsAffected = await _dataAccess.ExecuteAsync(userToInsert);

            var recordInserted = await _dataAccess.FetchAsync(new GetUserByUsername(_testGuid.ToString()));
            await _dataAccess.ExecuteAsync(new DeleteUser(recordInserted.Guid));

            Assert.Equal(-1, rowsAffected);
        }
    }
}
