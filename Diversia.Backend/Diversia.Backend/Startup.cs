using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Diversia.Backend.Startup))]
namespace Diversia.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
