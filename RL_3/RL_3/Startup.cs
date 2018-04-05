using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RL_3.Startup))]
namespace RL_3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
