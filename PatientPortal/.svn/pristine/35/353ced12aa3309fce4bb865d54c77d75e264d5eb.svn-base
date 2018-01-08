using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PatientPortal.Domain.Caching.MemCache;
using PatientPortal.Domain.Common;
using PatientPortal.Domain.LogManager;
using PatientPortal.Domain.Models.AUTHEN;
using PatientPortal.PatientServices.Models;
using PatientPortal.Provider.Common;
using PatientPortal.Provider.Models;
using PatientPortal.Utility.Application;
using PatientPortal.Utility.Files;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebMarkupMin.AspNet4.Mvc;
using WebMatrix.WebData;
using ConstantDomain = PatientPortal.Domain.Common.ValueConstant;
using ConstValPatientService = PatientPortal.PatientServices.Common.ValueConstant;

namespace PatientPortal.PatientServices.Controllers
{
    [AppHandleError]
    //[CompressContent]
    //[MinifyHtml]
    public class AccountController : Controller
    {
        private static string controllerName = string.Empty;
        private readonly IUserSession _userSession;
        private UserCache cacheUserData;

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        public AccountController(IUserSession userSession)
        {
            _userSession = userSession;
           // userCache = (UserCache)MemoryCacheObject.GetCacheObject(ObjectCacheProfile.CACHE_PROFILE_USER + _userSession.UserId);
        }
        // GET: /Account/Login
        [AllowAnonymous]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Login()
        {
            controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            if (WebSecurity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Session.Abandon();
            }
            Session["SessionId"] = HttpContext.Session.SessionID;
            return View();
        }

        public PartialViewResult _NavAccount()
        {

            return PartialView((cacheUserData == null ? AccessCacheUserData() : cacheUserData));
        }
        public PartialViewResult _NavSideAccount()
        {
            return PartialView((cacheUserData == null ? AccessCacheUserData() : cacheUserData));
        }

        private UserCache AccessCacheUserData()
        {
            var userCache = (UserCache)MemoryCacheObject.GetCacheObject(ObjectCacheProfile.CACHE_PROFILE_USER + _userSession.UserId);
            if (userCache == null)
            {
                UserSecretInfoViewModel info = APIProvider.Authorize_GetNonAsync<UserSecretInfoViewModel>(_userSession.BearerToken, "Account", "GetSecretInfo", null, APIConstant.API_Resource_Authorize);
                if (info != null)
                {
                    var patientId = (info.PatientId == null ? string.Empty : info.PatientId);
                    UserCache cacheUserData = new UserCache();
                    cacheUserData.Image = (info.Image != null ? FileManagement.ByteArrayToImageBase64(info.Image) : string.Empty);
                    cacheUserData.UserName = _userSession.UserName;
                    cacheUserData.PatientId = patientId;
                    cacheUserData.UserId = _userSession.UserId;

                    MemoryCacheObject.CacheObject(ObjectCacheProfile.CACHE_PROFILE_USER + _userSession.UserId, cacheUserData);

                    return cacheUserData;
                }
            }
            return userCache;
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            //Check Captcha
            if (GlobalVar.IsreCaptcha)
            {
                var response = Request["g-recaptcha-response"];
                var client = new WebClient();
                var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", ValueConstant.GooglereCAPTCHA_SecretKey, response));
                var obj = JObject.Parse(result);
                var status = (bool)obj.SelectToken("success");
                if (!status)
                {
                    ModelState.AddModelError(string.Empty, "");
                    TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.ERROR,
                        ApplicationGenerator.GeneralActionMessage(null, ApplicationGenerator.TypeResult.reCAPTCHA));
                    return View(model);
                }
            }

            var token = AuthenAPIHelper.GetToken(model.UserName, model.Password);
            if (string.IsNullOrEmpty(token.AccessToken))
            {
                var errorStr = "Có lỗi phát sinh khi đăng nhập: Không lấy được Token, kiểm tra tài khoản + password.";
                if (token.Json != null)
                {
                    var error = JsonConvert.DeserializeObject<dynamic>(token.Json.ToString());
                    errorStr = error.error_description.ToString();
                }

                ModelState.AddModelError(string.Empty, errorStr);
                TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.ERROR,
                    ApplicationGenerator.GeneralActionMessage(null, ApplicationGenerator.TypeResult.LOGINERROR));
                Logger.LogError(new Exception(errorStr));
                return View(model);
            }
            var tokenDynamic = JsonConvert.DeserializeObject<dynamic>(token.Json.ToString());
            string username = tokenDynamic.userName;
            string access_token = tokenDynamic.access_token;

            //Get Secret User Info
            UserSecretInfoViewModel info = await APIProvider.Authorize_Get<UserSecretInfoViewModel>(access_token, controllerName, "GetSecretInfo",null, APIConstant.API_Resource_Authorize);
            if(info == null)
            {
                ModelState.AddModelError(string.Empty, "Không tìm thấy thông tin tài khoản");
                TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.ERROR,
                    ApplicationGenerator.GeneralActionMessage(null, ApplicationGenerator.TypeResult.USER_NOT_EXIST));

                return View(model);
            }
            var patientId = (info.PatientId == null ? string.Empty : info.PatientId);

            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier,info.NameIdentifier , ClaimValueTypes.String),
                new Claim(ClaimTypes.Email,info.Email , ClaimValueTypes.String),
                new Claim(ClaimTypes.Name,info.Name , ClaimValueTypes.String),
                new Claim(ValueConstant.AccountName, username, ClaimValueTypes.String),
                //new Claim(ValueConstant.AccountImage, info.Image, ClaimValueTypes.),
                new Claim(ValueConstant.AccountPatient, (info.PatientId == null ? string.Empty : info.PatientId), ClaimValueTypes.String),
                new Claim(ValueConstant.TOKEN, string.Format("{0}", access_token), ClaimValueTypes.String)
            };

            UserCache cacheUserData = new UserCache();
            cacheUserData.Image = (info.Image != null ? FileManagement.ByteArrayToImageBase64(info.Image) : string.Empty);
            cacheUserData.UserName = username;
            cacheUserData.PatientId = patientId;
            cacheUserData.UserId = info.NameIdentifier;

            MemoryCacheObject.CacheObject(ObjectCacheProfile.CACHE_PROFILE_USER + info.NameIdentifier, cacheUserData);

            var claimsIdentity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, claimsIdentity);

            HttpContext.User = AuthenticationManager.AuthenticationResponseGrant.Principal;
            return RedirectToAction(returnUrl);
        }

        // GET: /Account/LogOff
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> Overview()
        {
            var model = new UserInfoBindingModel();
            try
            {
                var token = _userSession.BearerToken;
                controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                var id = _userSession.UserId;

                string strUrl = controllerName + "/GetInfoEdit?userId=" + id;
                model = await APIProvider.Authorize_Get<UserInfoBindingModel>(token, strUrl, APIConstant.API_Resource_Authorize, ARS.IgnoredARS);
                model.Id = id;

                return View(model);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        public async Task<ActionResult> PersonalInfo()
        {
            var model = new UserInfoBindingModel();
            try
            {
                var token = _userSession.BearerToken;
                controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                var id = _userSession.UserId;

                string strUrl = controllerName + "/GetInfoEdit?userId=" + id;
                model = await APIProvider.Authorize_Get<UserInfoBindingModel>(token, strUrl, APIConstant.API_Resource_Authorize, ARS.IgnoredARS);
                model.Id = id;

                return View(model);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PersonalInfo(UserInfoBindingModel model, HttpPostedFileBase fileUpload)
        {
            controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string strUrl = controllerName + ConstantDomain.UPDATE_USER;
            var token = _userSession.BearerToken;

            if (ModelState.IsValid)
            {
                try
                {
                    byte[] image = null;
                    MemoryStream target = new MemoryStream();
                    if (fileUpload != null)
                    {
                        fileUpload.InputStream.CopyTo(target);
                        image = target.ToArray();
                        cacheUserData = cacheUserData == null ? AccessCacheUserData() : cacheUserData;
                        cacheUserData.Image = FileManagement.ByteArrayToImageBase64(image);

                        model.Image = image;
                    }
                    var result = await APIProvider.Authorize_DynamicTransaction<UserInfoBindingModel, string>(model, token, strUrl, APIConstant.API_Resource_Authorize, ARS.IgnoredARS);

                    if (Response.StatusCode == 200)
                    {
                        TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.SUCCESS, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_UPDATE, ApplicationGenerator.TypeResult.SUCCESS));
                        return RedirectToAction("Overview");
                    }
                    else
                    {
                        return RedirectToAction("Overview");
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.ERROR, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_INSERT, ApplicationGenerator.TypeResult.ERROR));
                    throw ex;
                }
            }
            else
            {
                TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.SUCCESS, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_INSERT, ApplicationGenerator.TypeResult.SUCCESS));
                return RedirectToAction("Overview");
            }
        }
        public ActionResult _ChangePassword()
        {
            return PartialView("_ChangePassword");
        }

        public ActionResult ChangePassword()
        {
            var model = new ChangePasswordBindingModel();
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string strUrl = controllerName + ConstantDomain.CHANGE_PASSWORD;
            var token = _userSession.BearerToken;

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await APIProvider.Authorize_DynamicTransaction<ChangePasswordBindingModel, string>(model, token, strUrl, APIConstant.API_Resource_Authorize);

                    if (result == null)
                    {
                        TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.SUCCESS, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_INSERT, ApplicationGenerator.TypeResult.SUCCESS));
                        return RedirectToAction("Overview");
                    }
                    else
                    {
                        TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.FAIL, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_INSERT, ApplicationGenerator.TypeResult.FAIL));
                        return RedirectToAction("Overview");
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains(ConstValPatientService.INCORRECT_PASSWORD))
                    {
                        TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.INCORRECT_PASS, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_INSERT, ApplicationGenerator.TypeResult.INCORRECT_PASS));
                        return RedirectToAction("Overview");
                    }
                    else
                    {
                        Logger.LogError(ex);
                        TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.ERROR, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_INSERT, ApplicationGenerator.TypeResult.ERROR));
                        return RedirectToAction("Overview");
                    }
                }
            }
            else
            {
                return View(model);
            }
        }
    }
}