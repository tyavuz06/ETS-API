using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin;
using Owin;

namespace ETS.API
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions AuthOptions { get; private set; }

        static Startup()
        {
            AuthOptions = new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new Microsoft.Owin.PathString("/token"),
                Provider = new OAuthAppProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(2),
                AllowInsecureHttp = true
            };
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseOAuthBearerTokens(AuthOptions);
        }
    }
}
