using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Puestos_de_Trabajo.Startup))]
namespace Puestos_de_Trabajo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
