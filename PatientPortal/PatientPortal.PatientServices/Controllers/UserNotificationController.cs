using Microsoft.Owin.Security;
using PatientPortal.Domain.Models.AUTHEN;
using PatientPortal.PatientServices.Models;
using PatientPortal.Provider.Common;
using PatientPortal.Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebMarkupMin.AspNet4.Mvc;

namespace PatientPortal.PatientServices.Controllers
{
    [Authorize]
    [AppHandleError]
    //[CompressContent]
    //[MinifyHtml]
    public class UserNotificationController : Controller
    {
        private static string controllerName = string.Empty;
        private readonly IUserSession _userSession;
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public UserNotificationController(IUserSession userSession)
        {
            _userSession = userSession;
        }

        // GET: UserNotification
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData(int pageIndex, int numberInPage)
        {
            string apiNotificationUrl = APIProvider.APIGenerator("UserNotification", new List<string> { "userId", "NumTop", "pageIndex", "numberInPage" }, true, _userSession.UserId, 0, pageIndex, numberInPage);

            var data = APIProvider.Authorize_GetNonAsync<UserNotificationModel>(_userSession.BearerToken, apiNotificationUrl, APIConstant.API_Resource_CORE, ARS.IgnoredARS);
            if (data == null)
            {
                data = new UserNotificationModel();
                data.TotalItem = 0;
                data.lstUserNotificationViewModel = new List<UserNotificationViewModel>();
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<bool> UpdateStatus(List<string> ids)
        {
            string apiUrl = APIProvider.APIGenerator("UserNotification", new List<string> { "status" }, true, true);
            var result = await APIProvider.Authorize_DynamicTransaction<List<string>, bool>(ids, _userSession.BearerToken, apiUrl, APIConstant.API_Resource_CORE, ARS.Edit);

            return result;
        }
    }
}