using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ERAWeb.Startup))]
namespace ERAWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
