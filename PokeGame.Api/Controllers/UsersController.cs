using PokeGame.Orchestration.Handlers.Users;

namespace PokeGame.Api.Controllers
{
    public class UsersController : Controller
    {
        private readonly IOrchestrator _orchestrator;

        public UsersController(IOrchestrator orchestrator) => _orchestrator = orchestrator;

        [HttpGet("isUsernameTaken")]
        public async Task<bool> IsUsernameTaken(IsUsernameTakenRequest request) => await _orchestrator.FetchResponseAsync<IsUsernameTakenRequest, bool>(request);

        [HttpGet("isEmailTaken")]
        public async Task<bool> IsEmailTaken(IsEmailTakenRequest request) => await _orchestrator.FetchResponseAsync<IsEmailTakenRequest, bool>(request);

        [HttpGet("getUserByUsername")]
        public async Task<User> GetUserByUsername(GetUserByUsernameRequest request) => await _orchestrator.FetchResponseAsync<GetUserByUsernameRequest, User>(request);

        [HttpPost("insertUser")]
        public async Task InsertUser(InsertUserRequest request) => await _orchestrator.ExecuteRequestAsync(request);

        [HttpPost("deleteUser")]
        public async Task DeleteUser(DeleteUserRequest request) => await _orchestrator.ExecuteRequestAsync(request);
    }
}
