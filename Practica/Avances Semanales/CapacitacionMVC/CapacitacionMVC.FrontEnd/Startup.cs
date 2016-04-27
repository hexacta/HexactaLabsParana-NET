using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CapacitacionMVC.FrontEnd.Startup))]
namespace CapacitacionMVC.FrontEnd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
