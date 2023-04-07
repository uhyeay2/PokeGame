using PokeGame.Orchestration.Handlers.Users;

namespace PokeGame.Api.Controllers
{
    public class UsersController : Controller
    {
        private readonly IOrchestrator _orchestrator;

        public UsersController(IOrchestrator orchestrator) => _orchestrator = orchestrator;

        [HttpGet("isUsernameTaken")]
        public async Task<bool> IsUsernameTaken(IsUsernameTakenRequest request) => await _orchestrator.GetResponseAsync<IsUsernameTakenRequest, bool>(request);

        [HttpGet("isEmailTaken")]
        public async Task<bool> IsEmailTaken(IsEmailTakenRequest request) => await _orchestrator.GetResponseAsync<IsEmailTakenRequest, bool>(request);

        [HttpGet("getUserByUsername")]
        public async Task<User> GetUserByUsername(GetUserByUsernameRequest request) => await _orchestrator.GetResponseAsync<GetUserByUsernameRequest, User>(request);

        [HttpPost("insertUser")]
        public async Task<User> InsertUser(InsertUserRequest request) => await _orchestrator.GetResponseAsync<InsertUserRequest, User>(request);

        [HttpDelete("deleteUser")]
        public async Task DeleteUser(DeleteUserRequest request) => await _orchestrator.ExecuteRequestAsync(request);
    }
}
