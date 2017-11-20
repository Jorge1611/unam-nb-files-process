using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using WA_UNAM_NB_PR.Controllers.Services;
using WA_UNAM_NB_PR.Hubs;

[assembly: OwinStartupAttribute(typeof(WA_UNAM_NB_PR.Startup))]
namespace WA_UNAM_NB_PR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalHost.DependencyResolver.Register(
                typeof(ProcessHub),
                () => new ProcessHub( ProcessManager.Instance));
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
