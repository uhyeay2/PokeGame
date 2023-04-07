namespace PokeGame.Orchestration.Handlers.Encryption
{
    public class GetHashedValueRequest : RequiredStringInputRequest, IRequest<HashedValue> { }

    internal class GetHashedValueHandler : IHandler<GetHashedValueRequest, HashedValue>
    {
        private readonly IHash _hasher;

        public GetHashedValueHandler(IHash hasher) => _hasher = hasher;

        public HashedValue HandleRequest(GetHashedValueRequest request) => _hasher.GetHashedValue(request.Input);
    }
}
