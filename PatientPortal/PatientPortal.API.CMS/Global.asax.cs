using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;
using System;
using System.Threading;
using PatientPortal.Domain.LogManager;
using System.Web;
using System.IO.Compression;

namespace PatientPortal.API.CMS
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Automapper
            AutoMapperConfig.Configure();
            //Autofac
            //AutofacConfig.RegisterDependencies();
            //Log4Net
            log4net.Config.XmlConfigurator.Configure();
        }
        protected void Application_Error(Object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex is ThreadAbortException)
                return;
            Logger.LogError(ex);
        }

        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new System.Web.Http.AuthorizeAttribute());
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

            // Implement HTTP compression
            HttpApplication app = (HttpApplication)sender;


            // Retrieve accepted encodings
            string encodings = app.Request.Headers.Get("Accept-Encoding");
            if (encodings != null)
            {
                // Check the browser accepts deflate or gzip (deflate takes preference)
                encodings = encodings.ToLower();
                if (encodings.Contains("deflate"))
                {
                    app.Response.Filter = new DeflateStream(app.Response.Filter, CompressionMode.Compress);
                    app.Response.AppendHeader("Content-Encoding", "deflate");
                }
                else if (encodings.Contains("gzip"))
                {
                    app.Response.Filter = new GZipStream(app.Response.Filter, CompressionMode.Compress);
                    app.Response.AppendHeader("Content-Encoding", "gzip");
                }
            }
        }
    }
}
