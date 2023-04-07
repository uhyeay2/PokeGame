using PokeGame.DataAccess.DataRequests.Users;
using PokeGame.DataAccess.DataRequests.UsersPasswords;
using System.Text;

namespace PokeGame.DataAccess.Tests.DataRequestTests.UsersPasswords
{
    public class InsertUserPasswordTests : DataRequestTest
    {
        private InsertUserPassword NewInsertPasswordRequest(Guid? guid = null) => new InsertUserPassword( guid ?? _testGuid, Encoding.UTF8.GetBytes("Hash"), Encoding.UTF8.GetBytes("Hash"));

        [Fact]
        public async Task InsertUserPassword_Given_NoUserExistsWithGuid_Should_ReturnNegativeOne_RowsAffected()
        {
            var rowsAffected = await _dataAccess.ExecuteAsync(NewInsertPasswordRequest());

            Assert.Equal(-1, rowsAffected);
        }

        [Fact]
        public async Task InsertUserPassword_Given_UserPasswordAlreadyExists_Should_ReturnNegativeOne_RowsAffected()
        {
            var user = await _seeder.NewUserAsync();

            // First Insert to make a record already exist
            await _dataAccess.ExecuteAsync(NewInsertPasswordRequest());

            var rowsAffected = await _dataAccess.ExecuteAsync(NewInsertPasswordRequest());

            await _dataAccess.ExecuteAsync(new DeleteUser(user.Guid));

            Assert.Equal(-1, rowsAffected);
        }

        [Fact]
        public async Task InsertUserPassword_Given_UserPasswordIsInserted_Should_ReturnTwo_RowsAffected()
        {
            var user = await _seeder.NewUserAsync();

            var rowsAffected = await _dataAccess.ExecuteAsync(NewInsertPasswordRequest(user.Guid));

            await _dataAccess.ExecuteAsync(new DeleteUser(user.Guid));

            Assert.Equal(2, rowsAffected);
        }
    }
}
