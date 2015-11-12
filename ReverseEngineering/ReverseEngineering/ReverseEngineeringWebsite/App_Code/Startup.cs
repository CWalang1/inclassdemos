using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReverseEngineeringWebsite.Startup))]
namespace ReverseEngineeringWebsite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
