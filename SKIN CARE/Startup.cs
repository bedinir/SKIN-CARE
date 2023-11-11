using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SKIN_CARE.Startup))]
namespace SKIN_CARE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
