using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPcinema.Startup))]
namespace ASPcinema
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
