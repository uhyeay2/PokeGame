namespace PokeGame.DataAccess.Abstraction.Interfaces
{
    internal interface IDbConnectionFactory
    {
        System.Data.IDbConnection NewConnection();
    }
}
