using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebASP_Ajax.Startup))]
namespace WebASP_Ajax
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
