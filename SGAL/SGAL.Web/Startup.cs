using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SGAL.Web.Startup))]
namespace SGAL.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
