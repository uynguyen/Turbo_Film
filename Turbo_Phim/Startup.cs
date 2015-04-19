using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Turbo_Phim.Startup))]
namespace Turbo_Phim
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
