using Microsoft.Owin.Security.OAuth;
using ModernWebStore.Domain.Services;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace ModernWebStore.Api.Security
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        IUserApplicationService _userService;

        public SimpleAuthorizationServerProvider(IUserApplicationService userService)
        {
            _userService = userService;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var user = _userService.Authenticate(context.UserName, context.Password);
            if(user == null)
            {
                context.SetError("invalid_grant", "User or Password is invalid!");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Email));
            identity.AddClaim(new Claim(ClaimTypes.Role, user.IsAdmin ? "admin" : ""));

            var principal = new GenericPrincipal(identity, new string[] { user.IsAdmin ? "admin" : "" });
            Thread.CurrentPrincipal = principal;

            context.Validated(identity);
        }

    }
}