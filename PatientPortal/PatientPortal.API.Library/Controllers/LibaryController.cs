using PatientPortal.API.Library.Common;
using PatientPortal.API.Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PatientPortal.API.Library.Controllers
{
    public class LibaryController : ApiController
    {
        private readonly string LOCAL_PATH = ConfigurationManager.AppSettings["localPath"];
        private readonly string DOMAIN = ConfigurationManager.AppSettings["domain"];

        public IEnumerable<FileViewModel> GetListImage(string folder)
        {
            string fullPath = LOCAL_PATH + folder;
            var images = Directory.GetFiles(fullPath).Select(x => new FileViewModel
            {
                Url = DOMAIN + folder + Path.GetFileName(x)
            });
            return images;
        }
    }
}
