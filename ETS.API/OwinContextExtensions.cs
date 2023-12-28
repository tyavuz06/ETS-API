using Microsoft.Owin;

namespace ETS.API
{
    public static class OwinContextExtensions
    {
        public static string GetUserId(this IOwinContext ctx)
        {
            var response = "-1";
            var claim = ctx.Authentication.User.Claims.FirstOrDefault(c => c.Type == "UserId");

            if (claim != null)

                response = claim.Value;


            return response;
        }
    }
}
