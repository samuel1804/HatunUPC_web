using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HatunsolWeb.Startup))]
namespace HatunsolWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
