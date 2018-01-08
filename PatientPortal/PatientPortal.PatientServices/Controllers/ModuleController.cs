using Microsoft.Owin.Security;
using PatientPortal.Domain.Models.AUTHEN;
using PatientPortal.Domain.Models.SYSTEM;
using PatientPortal.PatientServices.Models;
using PatientPortal.Provider.Common;
using PatientPortal.Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMarkupMin.AspNet4.Mvc;

namespace PatientPortal.PatientServices.Controllers
{
    [Authorize]
    [AppHandleError]
    //[CompressContent]
    //[MinifyHtml]
    public class ModuleController : Controller
    {
        #region Authentication Manager
        private readonly IUserSession _userSession;
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ModuleController(IUserSession userSession)
        {
            _userSession = userSession;
        }
        #endregion
        // GET: Module
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _Nav()
        {
            ModuleShared lstModel = new ModuleShared();


            string strUrl = APIProvider.APIGenerator("Module", "Initial", new List<string> { "group" }, true, APIConstant.MODULE_PATIENT);
            var lstModule = APIProvider.Authorize_GetNonAsync<List<ModuleApplication>>(_userSession.BearerToken, strUrl, APIConstant.API_Resource_CORE, ARS.IgnoredARS);
            if (lstModule != null)
            {
                lstModel.lstModuleParent = lstModule.Where(x => x.ParentId == 0).ToList();
                lstModel.lstModuleItem = lstModule.Where(x => x.ParentId != 0).ToList();
            }

            return PartialView("_Nav", lstModel);
        }
    }
}