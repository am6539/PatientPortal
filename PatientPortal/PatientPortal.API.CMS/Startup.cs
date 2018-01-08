using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Autofac;

[assembly: OwinStartup(typeof(PatientPortal.API.CMS.Startup))]

namespace PatientPortal.API.CMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            HttpConfiguration config = new HttpConfiguration();
            ConfigureAuth(app);

            //Allow CORS for ASP.NET Web API
            WebApiConfig.Register(config);


            //Autofac
            IContainer container = AutofacConfig.RegisterDependencies();
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
        }
    }
}
