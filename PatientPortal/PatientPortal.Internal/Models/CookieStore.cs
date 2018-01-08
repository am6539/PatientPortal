using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PatientPortal.Internal.Models
{
    public static class CookieStore2
    {
        public static void Create(string name, object data, HttpContext context, double days = 12)
        {
            var dataParse = JsonConvert.SerializeObject(data);
            if(dataParse.Length > 0)
            {
                //Remove
                Remove(name, context);

                //Value
                var val = Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data, Formatting.Indented)));

                //Create new
                HttpCookie cookie = new HttpCookie(name);
                cookie.Expires.AddDays(days);
                cookie.Value = val;
                context.Response.Cookies.Add(cookie);
            }
        }

        public static void Remove(string name, HttpContext context)
        {
            //Remove
            if (context.Request.Cookies[name] != null)
            {
                context.Request.Cookies[name].Expires = DateTime.Now.AddDays(-1);
                context.Request.Cookies.Remove(name);
            }

        }

        public static HttpCookie Get(string name, HttpContext context)
        {
            //Remove
            if (context.Request.Cookies[name] != null)
            {
                return context.Request.Cookies[name];
            }
            return null;
        }

        public static T Get<T>(string name, HttpContext context)
        {
            //Remove
            if (context.Request.Cookies[name] != null)
            {

                try
                {
                    var val = Encoding.UTF8.GetString(Convert.FromBase64String(context.Request.Cookies[name].Value));
                    var data = JsonConvert.DeserializeObject<T>(val, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                   // data = JsonConvert.DeserializeObject<T>(context.Request.Cookies[name].Value);
                    return (data == null ? default(T) : data);
                }
                catch(Exception ex)
                {
                    return default(T);
                }
            }
            return default(T);
        }
    }
}