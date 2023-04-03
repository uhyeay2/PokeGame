namespace PokeGame.DataAccess.DataRequests.HashedValues
{
    public class GetHashedValue : IdRequest<DTO_HashedValue>
    {
        public GetHashedValue(int id) :base(id) { }

        public override string GetSql() => "SELECT * FROM HashedValues WHERE Id = @Id";
    }
}
