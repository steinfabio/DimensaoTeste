using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DimensaoTeste.Startup))]
namespace DimensaoTeste
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
