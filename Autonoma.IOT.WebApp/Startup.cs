using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Autonoma.IOT.WebApp.Startup))]
namespace Autonoma.IOT.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
