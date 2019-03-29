using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YourFairShare_MVC.Startup))]
namespace YourFairShare_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
