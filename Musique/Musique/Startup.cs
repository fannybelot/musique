using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Musique.Startup))]
namespace Musique
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
