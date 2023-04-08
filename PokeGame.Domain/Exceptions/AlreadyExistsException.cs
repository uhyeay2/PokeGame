namespace PokeGame.Domain.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(Type objectAlreadyExisting, List<(string NameOfField, object Value)> conflicts) 
        : this(objectAlreadyExisting, conflicts.ToArray()) { }

        public AlreadyExistsException(Type objectAlreadyExisting, params (string NameOfField, object Value)[] conflicts) =>
            Conflicts = conflicts.Select(c => $"{objectAlreadyExisting.Name} already exists with {c.NameOfField}: {c.Value}");

        public readonly IEnumerable<string> Conflicts;
    }
}
