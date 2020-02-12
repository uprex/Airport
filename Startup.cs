using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Airport.Startup))]
namespace Airport
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
