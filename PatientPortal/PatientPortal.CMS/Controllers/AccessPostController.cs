
using PatientPortal.CMS.Common;
using PatientPortal.CMS.Models;
using PatientPortal.Provider.Common;
using PatientPortal.Provider.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    public class AccessPostController : Controller
    {
        #region declare variable
        private readonly IUserSession _userSession;
        private static string controllerName = "Post";
        #endregion

        #region Contructor
        public AccessPostController(IUserSession userSession)
        {
            _userSession = userSession;
        }
        #endregion

        #region Read
        // GET: ApprovePost
        public async Task<ActionResult> Index(PostFilterViewModel param)
        {
            try
            {
                param.LanguageCode = ConfigurationManager.AppSettings["AdminLanguageCode"];

                //Call API Provider
                var listCatg = await APIProvider.Authorize_Get<List<CategoryViewModel>>(_userSession.BearerToken, "Category", APIConstant.API_Resource_CMS, ARS.Get);
                ViewBag.CategoryList = listCatg;

                //Post
                var lstPost = await APIProvider.Authorize_Get<List<PostListViewModel>>(_userSession.BearerToken, "Post", "GetAll", param, APIConstant.API_Resource_CMS, ARS.Get);
                param.PostListViewModel = lstPost;

                return View(param);
            }
            catch (HttpException ex)
            {
                Logger.LogError(ex);
                int statusCode = ex.GetHttpCode();
                if (statusCode == 401)
                {
                    TempData["Alert"] = ApplicationGenerator.RenderResult(FuntionType.Post, APIConstant.ACTION_ACCESS);
                    return new HttpUnauthorizedResult();
                }

                throw ex;
            }
        }
        #endregion

        #region Detail
        // GET: AccessPost/Preview/5
        public async Task<ActionResult> Preview(int id)
        {
            try
            {
                //Call API Provider
                string strUrl = APIProvider.APIGenerator(this, this.RouteData.Values["action"].ToString(), id);
                var model = await APIProvider.Authorize_Get<PostViewModel>(_userSession.BearerToken, controllerName + strUrl, APIConstant.API_Resource_CMS, ARS.Get);

                if (string.IsNullOrEmpty(model.Image))
                {
                    model.Image = ValueConstant.IMAGE_PATH + ValueConstant.IMAGE_POST_PATH + ValueConstant.IMAGE_DEFAULT;
                }
                if (model.Tag != string.Empty) ViewBag.Tags = model.Tag;

                return View(model);
            }
            catch (HttpException ex)
            {
                Logger.LogError(ex);
                int statusCode = ex.GetHttpCode();
                if (statusCode == 401)
                {
                    TempData["Alert"] = ApplicationGenerator.RenderResult(FuntionType.Post, APIConstant.ACTION_ACCESS);
                    return new HttpUnauthorizedResult();
                }

                throw ex;
            }
        }
        #endregion

        #region Approve
        [HttpPost]
        public async Task<ActionResult> Approve(AccessPostViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Call API Provider 
                    string strUrl = APIProvider.APIGenerator("Post/ApproveAccess", APIConstant.ACTION_UPDATE);
                    var result = await APIProvider.Authorize_DynamicTransaction<AccessPostViewModel, bool>(model, _userSession.BearerToken, strUrl, APIConstant.API_Resource_CMS, ARS.IgnoredARS);

                    if (result == true)
                    {
                        TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.SUCCESS_APPROVE, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_APPROVE, ApplicationGenerator.TypeResult.SUCCESS_APPROVE));
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.FAIL_APPROVE, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_APPROVE, ApplicationGenerator.TypeResult.FAIL_APPROVE));
                        return RedirectToAction("Index");
                    }
                }
                catch
                {
                    TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.ERROR, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_APPROVE, ApplicationGenerator.TypeResult.ERROR));
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.FAIL_APPROVE, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_APPROVE, ApplicationGenerator.TypeResult.FAIL_APPROVE));
                return RedirectToAction("Index");
            }
        }
        #endregion
    }
}
