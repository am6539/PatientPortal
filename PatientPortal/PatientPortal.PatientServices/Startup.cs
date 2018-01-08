using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PatientPortal.PatientServices.Startup))]
namespace PatientPortal.PatientServices
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //var config = new HubConfiguration();
            //config.EnableJSONP = true;
            //app.MapSignalR(config);
        }
    }
}