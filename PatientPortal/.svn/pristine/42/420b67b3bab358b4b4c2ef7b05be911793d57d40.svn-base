using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;


[assembly: OwinStartup(typeof(PatientPortal.API.Core.Startup))]
namespace PatientPortal.API.Core
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            ConfigureAuth(app);

            //Allow CORS for ASP.NET Web API
            WebApiConfig.Register(config);
           

            //Autofac
            IContainer container=  AutofacConfig.RegisterDependencies();
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
        }
    }
}