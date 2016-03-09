using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectDazza.Web.Startup))]
namespace ProjectDazza.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
