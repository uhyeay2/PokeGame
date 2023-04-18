using PokeGame.Domain.Enums;
using PokeGame.Orchestration.Handlers.Users;
using System.Security.Claims;

namespace PokeGame.Orchestration.Handlers.Authentication
{
    public class GetClaimsPrincipalRequest : RequiredGuidRequest<ClaimsPrincipal>
    {
        public GetClaimsPrincipalRequest() { }

        public GetClaimsPrincipalRequest(Guid guid) : base(guid) { }
    }

    internal class GetClaimsPrincipalHandler : OrchestrationHandler<GetClaimsPrincipalRequest, ClaimsPrincipal>
    {
        public GetClaimsPrincipalHandler(IOrchestrator orchestrator) : base(orchestrator) { }

        public override async Task<ClaimsPrincipal> HandleRequestAsync(GetClaimsPrincipalRequest request)
        {
            var user = await _orchestrator.GetResponseAsync<GetUserByGuidRequest, User>(new(request.Guid));

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Guid.ToString()),
                new Claim(ClaimTypes.Role, nameof(RoleType.Member))
            };

            var identity = new ClaimsIdentity(claims, "UserSpecified");

            return new ClaimsPrincipal(identity);
        }
    }
}
