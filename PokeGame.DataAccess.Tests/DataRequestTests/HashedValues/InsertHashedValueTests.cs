using PokeGame.DataAccess.DataRequests.HashedValues;

namespace PokeGame.DataAccess.Tests.DataRequestTests.HashedValues
{
    public class InsertHashedValueTests : DataRequestTest
    {
        [Fact]
        public async Task InsertHashedValue_Given_HashAndSalt_Should_InsertHashedValue()
        {
            InsertHashedValue insertRequest = _requests.InsertHashedValue();

            var rowsAffected = await _dataAccess.ExecuteAsync(insertRequest);

            var recordInserted = await _dataAccess.FetchAsync(new GetHashedValueByHashAndSalt(insertRequest.Hash, insertRequest.Salt));

            await _dataAccess.ExecuteAsync(new DeleteHashedValue(recordInserted.Id));

            Assert.Multiple(() =>
            {

                Assert.Equal(1, rowsAffected);

                Assert.NotNull(recordInserted);

                Assert.Equal(insertRequest.Hash, recordInserted.Hash);
                Assert.Equal(insertRequest.Salt, recordInserted.Salt);
            });
        }
    }
}
