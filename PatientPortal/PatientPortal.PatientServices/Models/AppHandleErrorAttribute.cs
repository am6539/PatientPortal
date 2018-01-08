using PatientPortal.Domain.LogManager;
using PatientPortal.Utility.Application;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PatientPortal.PatientServices.Models
{
    public class AppHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;

            var statusCode = ex.HResult;
            //try
            //{
            //    statusCode = ((HttpException)ex).GetHttpCode();
            //}
            //catch
            //{

            //}
            // Log Exception ex in database
            Logger.LogError(ex);

            // Notify  admin team
            filterContext.ExceptionHandled = true;

            //Unauthorized
            if (statusCode == 401)
            {
                filterContext.Controller.TempData["Alert"] = ApplicationGenerator.RenderResult();
                string controller = filterContext.RouteData.Values["controller"].ToString();
                string action = filterContext.RouteData.Values["action"].ToString();

                if (action == "Index")
                {
                    filterContext.Result = new ViewResult()
                    {
                        ViewName = "~/HttpErrors/Unauthorized"
                    };
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        action = "Index",
                        controller = controller
                    }));
                }
            }
            else
            {
                string viewName = "Error";

                switch (statusCode)
                {
                    case 404:
                        viewName = "NotFound";
                        break;

                    case 500:
                    default:
                        viewName = "Error";
                        break;
                }
                filterContext.Result = new ViewResult()
                {
                    ViewName = "~/HttpErrors/" + viewName
                };
            }
        }
    }
}