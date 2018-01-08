using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebMarkupMin.AspNet4.Mvc;

namespace PatientPortal.CMS.Controllers
{
    [AllowAnonymous]
    //[CompressContent]
    [MinifyHtml]
    public class HttpErrorsController : Controller
    {
        protected override void HandleUnknownAction(string actionName)
        {
            if (this.GetType() != typeof(HttpErrorsController))
            {
                var errorRoute = new RouteData();
                errorRoute.Values.Add("controller", "HttpErrors");
                errorRoute.Values.Add("action", "NotFound");
                errorRoute.Values.Add("url", HttpContext.Request.Url.OriginalString);

                View("NotFound").ExecuteResult(this.ControllerContext);
            }
        }

        // GET: HttpErrors
        public ActionResult NotFound()
        {
            //Response.StatusCode = 404;
            //Response.TrySkipIisCustomErrors = true;

            var statusCode = (int)System.Net.HttpStatusCode.NotFound;
            Response.StatusCode = statusCode;
            Response.TrySkipIisCustomErrors = true;
            HttpContext.Response.StatusCode = statusCode;
            HttpContext.Response.TrySkipIisCustomErrors = true;
            return View();
        }

        public ActionResult Error()
        {
            Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }

        public ActionResult Unauthorized()
        {
            Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
    }
}