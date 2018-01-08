using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Hosting;
using System.Security.Cryptography;
using System.Text;

namespace PatientPortal.API.Video.Controllers
{
    /// <summary>
    /// This is our video streaming service.
    /// The below action is designed for demo purposes only and may not be suitable for production enviroments.
    /// </summary>
    [Authorize]
    public class VideoController : ApiController
    {
        private string videosPath = HostingEnvironment.MapPath("~/Videos");

        [AllowAnonymous]
        public HttpResponseMessage Get(string filename)
        {
            if (filename == null)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            string filePath = videosPath + "\\" + filename;

            if (Request.Headers.Range != null)
            {
                //Range Specifc request: Stream video on wanted range.
                try
                {
                    //NOTE: ETag calculation only with file name is one approach (Not the best one though - GUIDs or DateTime is may required in live applications.).
                    Encoder stringEncoder = Encoding.UTF8.GetEncoder();
                    byte[] stringBytes = new byte[stringEncoder.GetByteCount(filePath.ToCharArray(), 0, filePath.Length, true)];
                    stringEncoder.GetBytes(filePath.ToCharArray(), 0, filePath.Length, stringBytes, 0, true);
                    MD5CryptoServiceProvider MD5Enc = new MD5CryptoServiceProvider();
                    string hash = BitConverter.ToString(MD5Enc.ComputeHash(stringBytes)).Replace("-", string.Empty);

                    HttpResponseMessage partialResponse = Request.CreateResponse(HttpStatusCode.PartialContent);
                    partialResponse.Headers.AcceptRanges.Add("bytes");
                    partialResponse.Headers.ETag = new EntityTagHeaderValue("\"" + hash + "\"");

                    var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    partialResponse.Content = new ByteRangeStreamContent(stream, Request.Headers.Range, new MediaTypeHeaderValue("video/mp4"));
                    return partialResponse;
                }
                catch (Exception)
                {
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.RequestedRangeNotSatisfiable);
            }
        }
    }
}