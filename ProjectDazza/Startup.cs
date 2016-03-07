using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectDazza.Startup))]
namespace ProjectDazza
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
