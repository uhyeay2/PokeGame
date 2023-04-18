using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using PokeGame.Orchestration.Handlers.Authentication;
using PokeGame.Orchestration.Handlers.Users;
using PokeGame.Orchestration.Handlers.UsersPasswords;
using System.Security.Claims;

namespace PokeGame.Api.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IOrchestrator _orchestrator;

        public AuthenticationController(IOrchestrator orchestrator) => _orchestrator = orchestrator;

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(string userName, string password, string? returnUrl = null)
        {
            var user = await _orchestrator.GetResponseAsync<GetUserByUsernameRequest, User>(new GetUserByUsernameRequest(userName));

            var isMatchingPassword = await _orchestrator.GetResponseAsync<IsMatchingUserPasswordRequest, bool>(new IsMatchingUserPasswordRequest(user.Guid, password));

            if (isMatchingPassword)
            {
                var principal = await _orchestrator.GetResponseAsync<GetClaimsPrincipalRequest, ClaimsPrincipal>(new (user.Guid));

                await HttpContext.SignInAsync(principal);

                return Redirect(returnUrl ?? "/");
            }

            return Denied();
        }

        [HttpPost("SignOut")]
        public async Task<IActionResult> Signout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/");
        }

        [Authorize]
        [HttpGet("GetClaimsPrincipal")]
        public async Task<ClaimsPrincipal> GetClaimsPrincipalAsync(GetClaimsPrincipalRequest request) =>
            await _orchestrator.GetResponseAsync<GetClaimsPrincipalRequest, ClaimsPrincipal>(request);

        public IActionResult Denied()
        {
            return View();
        }
    }
}
