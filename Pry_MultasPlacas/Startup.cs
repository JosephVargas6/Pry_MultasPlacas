using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pry_MultasPlacas.Startup))]
namespace Pry_MultasPlacas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
