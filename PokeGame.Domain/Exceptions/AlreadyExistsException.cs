namespace PokeGame.Domain.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        List<string> ItemsAlreadyExisting = new List<string>();

        public AlreadyExistsException(List<string> itemsAlreadyExisting) => ItemsAlreadyExisting = itemsAlreadyExisting;

        public AlreadyExistsException(string itemAlreadyExisting) : this(new List<string>() { itemAlreadyExisting } ) { }
    }
}
