using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WA_UNAM_NB_PR.Startup))]
namespace WA_UNAM_NB_PR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
