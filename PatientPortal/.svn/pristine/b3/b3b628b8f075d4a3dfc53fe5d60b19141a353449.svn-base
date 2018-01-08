using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http.Filters;

namespace PatientPortal.API.SPA.Models
{
    public class CacheFilter: ActionFilterAttribute
    {
        //Minutes
        public int TimeDuration { get; set; }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response.Headers.CacheControl = new CacheControlHeaderValue
            {
                MaxAge = TimeSpan.FromMinutes(TimeDuration),
                MustRevalidate = true,
                Public = true
            };
        }
    }
}