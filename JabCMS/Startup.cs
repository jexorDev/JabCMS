using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JabCMS.Startup))]
namespace JabCMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
