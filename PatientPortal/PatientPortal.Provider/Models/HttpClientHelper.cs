using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Provider.Models
{
    public class HttpClientHelper
    {
        public static HttpClient GetHttpClient(string token)
        {
            var httpClient = new HttpClient();
            if (token == null) throw new ArgumentNullException(nameof(token));
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", token));
            return httpClient;
        }
    }
}
