namespace PokeGame.DataAccess.Abstraction.Interfaces
{
    public interface IDataRequest
    {
        string GetSql();

        object? GetParameters();
    }

    public interface IDataRequest<TResponse> : IDataRequest { }
}
