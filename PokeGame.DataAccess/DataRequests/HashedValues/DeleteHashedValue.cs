namespace PokeGame.DataAccess.DataRequests.HashedValues
{
    public class DeleteHashedValue : IdRequest
    {
        public DeleteHashedValue(int id) : base(id) { }

        public override string GetSql() => "DELETE FROM HashedValues WHERE Id = @Id";
    }
}
