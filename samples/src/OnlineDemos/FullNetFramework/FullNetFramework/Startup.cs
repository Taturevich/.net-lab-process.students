using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FullNetFramework.Startup))]
namespace FullNetFramework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
