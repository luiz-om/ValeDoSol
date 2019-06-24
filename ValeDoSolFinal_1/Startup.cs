using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ValeDoSolFinal_1.Startup))]
namespace ValeDoSolFinal_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
