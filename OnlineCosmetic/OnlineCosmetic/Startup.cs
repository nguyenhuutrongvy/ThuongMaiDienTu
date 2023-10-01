using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineCosmetic.Startup))]
namespace OnlineCosmetic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
