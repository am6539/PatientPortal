using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using WebApiContrib.Formatting;

namespace PatientPortal.API.SPA.Utility
{
    internal static class APIHelper
    {
        private static Uri _baseAddress = new Uri(ConfigurationManager.AppSettings["webapi:library"]);


        public static T Get<T>(string urlApi)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-protobuf"));
                    httpClient.BaseAddress = _baseAddress;

                    var response = httpClient.GetAsync(urlApi).Result;

                    var data = response.Content.ReadAsAsync<T>(new[] { new ProtoBufFormatter() }).Result;

                    return data;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}