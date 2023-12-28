using Owin;

namespace ETS.API
{
    public partial class Startup
    {
        public Startup() { }

        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }    
    }
}
