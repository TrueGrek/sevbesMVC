using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(sevbesMVC.Startup))]
namespace sevbesMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
