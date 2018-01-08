using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.CMS.Models
{
    public class Cookies
    {
        public void Create(string name, object data, HttpContext context, double days = 12)
        {
            var dataParse = JsonConvert.SerializeObject(data);
            if (dataParse.Length > 0)
            {
                //Remove
                Remove(name, context);

                //Create new
                HttpCookie cookie = new HttpCookie(name);
                cookie.Expires.AddDays(days);
                cookie.Value = JsonConvert.SerializeObject(data);
                context.Response.Cookies.Add(cookie);
            }
        }

        public void Remove(string name, HttpContext context)
        {
            //Remove
            if (context.Request.Cookies[name] != null)
            {
                context.Request.Cookies[name].Expires = DateTime.Now.AddDays(-1);
            }
        }

        public HttpCookie Get(string name, HttpContext context)
        {
            //Remove
            if (context.Request.Cookies[name] != null)
            {
                return context.Request.Cookies[name];
            }
            return null;
        }
    }
}