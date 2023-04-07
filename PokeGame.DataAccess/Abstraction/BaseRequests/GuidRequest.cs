namespace PokeGame.DataAccess.Abstraction.BaseRequests
{
    public abstract class GuidRequest : IDataRequest
    {
        public GuidRequest(Guid guid) => Guid = guid;

        public Guid Guid { get; set; }

        public virtual object? GetParameters() => new { Guid };

        public abstract string GetSql();
    }

    public abstract class GuidRequest<TResponse> : GuidRequest, IDataRequest<TResponse>
    {
        protected GuidRequest(Guid guid) : base(guid) { }
    }
}
