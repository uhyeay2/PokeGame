using PokeGame.Orchestration.Handlers.Encryption;

namespace PokeGame.Api.Controllers
{
    public class EncryptionController : Controller
    {
        private readonly IOrchestrator _orchestrator;

        public EncryptionController(IOrchestrator orchestrator) => _orchestrator = orchestrator;

        [HttpGet("GetHashedValue")]
        public HashedValue GetHashedValue(GetHashedValueRequest request) => _orchestrator.GetResponse<GetHashedValueRequest, HashedValue>(request);

        [HttpGet("IsMatchingHashedValue")]
        public bool IsMatchingHashedValue(IsMatchingHashedValueRequest request) =>  _orchestrator.GetResponse<IsMatchingHashedValueRequest, bool>(request);
    }
}
