
using PatientPortal.CMS.Common;
using PatientPortal.CMS.Models;
using PatientPortal.Provider.Common;
using PatientPortal.Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PatientPortal.Utility.Application;
using PatientPortal.Domain.LogManager;
using PatientPortal.Domain.Models.AUTHEN;
using static PatientPortal.Utility.Application.ApplicationGenerator;
//using WebMarkupMin.AspNet4.Mvc;

namespace PatientPortal.CMS.Controllers
{
    [Authorize]
    [AppHandleError]
    //[CompressContent]
    //[MinifyHtml]
    public class LinkBuildingController : Controller
    {
        private static string controllerName = string.Empty;
        private readonly IUserSession _userSession;

        public LinkBuildingController(IUserSession userSession)
        {
            _userSession = userSession;
        }

        // GET: Language
        public async Task<ActionResult> Index()
        {
            try
            {
                var results = new LinkBuildingModel();
                //Call API Provider
                controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                var list = await APIProvider.Authorize_Get<List<LinkBuildingViewModel>>(_userSession.BearerToken, controllerName, APIConstant.API_Resource_CMS, ARS.Get);

                var data = new LinkBuildingViewModel();
                results.lstLinkBuildingViewModel = list;
                results.LinkBuildingViewModel = data;

                TempData["Data"] = list;
                return View(results);
            }
            catch (HttpException ex)
            {
                Logger.LogError(ex);
                int statusCode = ex.GetHttpCode();
                if (statusCode == 401)
                {
                    TempData["Alert"] = ApplicationGenerator.RenderResult(FuntionType.Department, APIConstant.ACTION_ACCESS);
                    return new HttpUnauthorizedResult();
                }

                throw ex;
            }
        }

        #region Create
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Create(LinkBuildingViewModel model)
        {
            try
            {
                if (model == null) return null;

                if (ModelState.IsValid)
                {
                    //Call API Provider
                    string strUrl = APIProvider.APIGenerator(controllerName, APIConstant.ACTION_INSERT);
                    var result = await APIProvider.Authorize_DynamicTransaction<LinkBuildingViewModel, bool>(model, _userSession.BearerToken, strUrl, APIConstant.API_Resource_CMS, ARS.Insert);

                    if (result)
                    {
                        TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.SUCCESS, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_INSERT, ApplicationGenerator.TypeResult.SUCCESS));
                    }
                    else
                    {
                        TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.FAIL, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_INSERT, ApplicationGenerator.TypeResult.ERROR));
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    var links = new LinkBuildingModel();
                    links.lstLinkBuildingViewModel = (List<LinkBuildingViewModel>)TempData["Data"];
                    links.LinkBuildingViewModel = model;

                    TempData["Data"] = links.lstLinkBuildingViewModel;
                    return View("Index", links);
                }
            }
            catch (HttpException ex)
            {
                Logger.LogError(ex);
                int statusCode = ex.GetHttpCode();
                if (statusCode == 401)
                {
                    TempData["Alert"] = ApplicationGenerator.RenderResult(FuntionType.Department, APIConstant.ACTION_ACCESS);
                    return new HttpUnauthorizedResult();
                }

                throw ex;
            }
        }
        #endregion

        #region Edit
        public async Task<ActionResult> Edit(short id)
        {
            var data = new LinkBuildingViewModel();
            try
            {
                if (!await APIProvider.Authorization(_userSession.BearerToken, ARS.Edit))
                {
                    TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.FuntionType.Account, APIConstant.ACTION_UPDATE);
                    return RedirectToAction("Index");
                }
                else
                {
                    //Call API Provider
                    string strUrl = controllerName + APIProvider.APIGenerator(this, this.RouteData.Values["action"].ToString(), id);
                    data = await APIProvider.Authorize_Get<LinkBuildingViewModel>(_userSession.BearerToken, strUrl, APIConstant.API_Resource_CMS, ARS.Get);
                    //var list = await APIProvider.Get<List<LinkBuildingViewModel>>(controllerName);
                }
                return View(data);
            }
            catch (HttpException ex)
            {
                Logger.LogError(ex);
                int statusCode = ex.GetHttpCode();
                if (statusCode == 401)
                {
                    TempData["Alert"] = ApplicationGenerator.RenderResult(FuntionType.Department, APIConstant.ACTION_ACCESS);
                    return new HttpUnauthorizedResult();
                }

                throw ex;
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Edit(LinkBuildingViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Call API Provider 
                string strUrl = APIProvider.APIGenerator(controllerName, APIConstant.ACTION_UPDATE);
                var result = await APIProvider.Authorize_DynamicTransaction<LinkBuildingViewModel, bool>(model, _userSession.BearerToken, strUrl, APIConstant.API_Resource_CMS, ARS.IgnoredARS);

                if (result)
                {
                    TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.SUCCESS, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_UPDATE, ApplicationGenerator.TypeResult.SUCCESS));
                }
                else
                {
                    TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.ERROR, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_UPDATE,ApplicationGenerator.TypeResult.ERROR));
                }
                return RedirectToAction("Index");
            }
            else
            {
                var links = new LinkBuildingModel();
                links.lstLinkBuildingViewModel = (List<LinkBuildingViewModel>)TempData["Data"];
                links.LinkBuildingViewModel = model;

                TempData["Data"] = links.lstLinkBuildingViewModel;
                return View("Index", links);
            }
        }
        #endregion

        #region Check exist
        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> CheckExist(string title, short id)
        {

            //Call API Provider - Get data
            string apiUrl = APIProvider.APIGenerator(controllerName, new List <string> { nameof(id), nameof(title) }, false, id, title.Trim());
            var isExist = await APIProvider.Authorize_Get<bool>(_userSession.BearerToken, apiUrl, APIConstant.API_Resource_CMS, ARS.Get);

            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Delete
        public async Task<ActionResult> Delete(LinkBuildingViewModel model)
        {
            try
            {
                if (!await APIProvider.Authorization(_userSession.BearerToken, ARS.Delete))
                {
                    TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.FuntionType.Article, APIConstant.ACTION_DELETE);
                    return RedirectToAction("Index");
                }
                else
                    return PartialView("_Delete", model);
            }
            catch (HttpException ex)
            {
                Logger.LogError(ex);
                int statusCode = ex.GetHttpCode();
                if (statusCode == 401)
                {
                    TempData["Alert"] = ApplicationGenerator.RenderResult(FuntionType.Department, APIConstant.ACTION_ACCESS);
                    return new HttpUnauthorizedResult();
                }

                throw ex;
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> Delete(short id)
        {
            var model = new LinkBuildingViewModel();
            model.Id = id;

            //Call API Provider - Transaction
            string apiUrl = APIProvider.APIGenerator(controllerName, APIConstant.ACTION_DELETE);
            var result = await APIProvider.Authorize_DynamicTransaction<LinkBuildingViewModel, bool>(model, _userSession.BearerToken, apiUrl, APIConstant.API_Resource_CMS, ARS.IgnoredARS);

            if (result)
            {
                TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.SUCCESS, "Xóa thành công");
            }
            else
            {
                TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.FAIL, "Xóa không thành công");
            }
            return RedirectToAction("Index");
        }
        #endregion

    }
}