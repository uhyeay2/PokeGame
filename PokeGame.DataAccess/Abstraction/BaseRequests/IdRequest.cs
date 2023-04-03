namespace PokeGame.DataAccess.Abstraction.BaseRequests
{
    public abstract class IdRequest : IDataRequest
    {
        public IdRequest(int id) => Id = id;

        public int Id { get; set; }

        public object? GetParameters() => new { Id };

        public abstract string GetSql();
    }

    public abstract class IdRequest<TResponse> : IdRequest, IDataRequest<TResponse>
    {
        protected IdRequest(int id) : base(id) { }
    }
}
