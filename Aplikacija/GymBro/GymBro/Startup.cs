using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GymBro.Startup))]
namespace GymBro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
