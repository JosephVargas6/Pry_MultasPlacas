using Microsoft.Owin;
using Owin;
using System.Web.Configuration;
using System.Web.Security;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;

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
