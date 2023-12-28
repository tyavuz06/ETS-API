using ETS.Business.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;

namespace ETS.API
{
    public class OAuthAppProvider : OAuthAuthorizationServerProvider
    {
        public OAuthAppProvider() { }   

        private readonly IUserService _userBusiness;
        public OAuthAppProvider(IUserService userBusiness) => (_userBusiness) = (userBusiness);

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                var username = context.UserName;
                var password = context.Password;
                var user = _userBusiness.GetUserByCredentials(username, password);

                if (user != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim("UserId", user.Id)
                    };

                    var authIdentity = new ClaimsIdentity(claims);
                    context.Validated(new Microsoft.Owin.Security.AuthenticationTicket(authIdentity, new Microsoft.Owin.Security.AuthenticationProperties() { }));
                }
                else
                    context.SetError("invalid_grant", "error");
            });
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
                context.Validated();
            return Task.FromResult<object>(null);
        }
    }
}
