using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HiringFair.WebMVC.Startup))]
namespace HiringFair.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
