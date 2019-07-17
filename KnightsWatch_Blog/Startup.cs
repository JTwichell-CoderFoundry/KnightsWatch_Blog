using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KnightsWatch_Blog.Startup))]
namespace KnightsWatch_Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
