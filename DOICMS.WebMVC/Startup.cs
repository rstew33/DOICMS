using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DOICMS.WebMVC.Startup))]
namespace DOICMS.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
