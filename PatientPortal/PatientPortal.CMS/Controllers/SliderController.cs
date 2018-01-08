﻿using PatientPortal.CMS.Common;
using PatientPortal.CMS.Models;
using PatientPortal.Provider.Common;
using PatientPortal.Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PatientPortal.Utility.Files;
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
    public class SliderController : Controller
    {
        private static string controllerName = string.Empty;
        private readonly IUserSession _userSession;

        public SliderController(IUserSession userSession)
        {
            _userSession = userSession;
        }

        #region Get List
        // GET: Feature
        public async Task<ActionResult> Index()
        {
            var results = new SliderModel();
            try
            {
                //Call API Provider
                controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                var list = await APIProvider.Authorize_Get<List<SliderViewModel>>(_userSession.BearerToken, controllerName, APIConstant.API_Resource_CMS, ARS.Get);

                var model = new SliderViewModel() { IsUsed = true };

                results.lstSliderViewModel = list;
                results.SliderViewModel = model;

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
        #endregion

        #region Create
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Create(SliderViewModel model, HttpPostedFileBase fileUpload)
        {
            try
            {
                if (fileUpload == null)
                {
                    ModelState.AddModelError("Image", "Vui lòng chọn hình");
                }
                if (ModelState.IsValid)
                {
                    if (fileUpload != null)
                    {
                        model.Image = fileUpload.FileName;
                        string imgName = "";

                        int[] demiSize = LayoutGuide.GetDefaultSize(Image_ModuleName.Slider);
                        if(demiSize == null)
                        {
                            FileManagement.UploadImage(fileUpload, ValueConstant.IMAGE_SLIDER_PATH, ref imgName);
                        }
                        else
                        {
                            FileManagement.UploadImage(fileUpload, ValueConstant.IMAGE_SLIDER_PATH, ref imgName, demiSize[0], demiSize[1]);
                        }
                        
                        model.Image = imgName;
                    }

                    //Call API Provider
                    string strUrl = APIProvider.APIGenerator(controllerName, APIConstant.ACTION_INSERT);
                    var result = await APIProvider.Authorize_DynamicTransaction<SliderViewModel, bool>(model, _userSession.BearerToken, strUrl, APIConstant.API_Resource_CMS, ARS.Insert);

                    if (result)
                    {
                        TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.SUCCESS, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_INSERT, ApplicationGenerator.TypeResult.SUCCESS));
                    }
                    else
                    {
                        TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.FAIL, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_INSERT, ApplicationGenerator.TypeResult.FAIL));
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    var slider = new SliderModel();
                    if (TempData["Data"] == null)
                    {
                        slider.lstSliderViewModel = await APIProvider.Authorize_Get<List<SliderViewModel>>(_userSession.BearerToken, controllerName, APIConstant.API_Resource_CMS, ARS.Get);
                    }
                    else
                    {
                        slider.lstSliderViewModel = (List<SliderViewModel>)TempData["Data"];
                    }

                    if (slider.lstSliderViewModel == null) slider.lstSliderViewModel = ApplicationGenerator.GetObject<List<SliderViewModel>>();
                    slider.SliderViewModel = model;

                    TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.FAIL, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_INSERT, ApplicationGenerator.TypeResult.FAIL));
                    return View("Index", slider);
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

        [HttpGet]
        public async Task<ActionResult> Edit(short id)
        {
            var model = new SliderViewModel();
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
                    string strUrl = APIProvider.APIGenerator(this, this.RouteData.Values["action"].ToString(), id);
                    model = await APIProvider.Authorize_Get<SliderViewModel>(_userSession.BearerToken, controllerName + strUrl, APIConstant.API_Resource_CMS, ARS.Get);

                    if (!string.IsNullOrEmpty(model.Image) && !model.Image.Contains(ValueConstant.IMAGE_SLIDER_PATH))
                    {
                        model.Image = ValueConstant.IMAGE_SLIDER_PATH + "/" + model.Image;
                    }
                }
                return View(model);
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
        public async Task<ActionResult> Edit(SliderViewModel model, HttpPostedFileBase fileUpload)
        {
            if (fileUpload == null && String.IsNullOrEmpty(model.Image))
            {
                ModelState.AddModelError("Image", "Vui lòng chọn hình");
            }

            if (ModelState.IsValid)
            {
                if (fileUpload != null)
                {
                    model.Image = fileUpload.FileName;
                    string imgName = "";
                    FileManagement.UploadImage(fileUpload, ValueConstant.IMAGE_SLIDER_PATH, ref imgName);
                    model.Image = imgName;
                }

                //Call API Provider 
                string strUrl = APIProvider.APIGenerator(controllerName, APIConstant.ACTION_UPDATE);
                var result = await APIProvider.Authorize_DynamicTransaction<SliderViewModel, bool>(model, _userSession.BearerToken, strUrl, APIConstant.API_Resource_CMS, ARS.IgnoredARS);

                if (result)
                {
                    TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.SUCCESS, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_UPDATE, ApplicationGenerator.TypeResult.SUCCESS));
                }
                else
                {
                    TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.FAIL, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_UPDATE, ApplicationGenerator.TypeResult.FAIL));
                }
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.FAIL, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_UPDATE, ApplicationGenerator.TypeResult.FAIL));
                return View(model);
            }
        }
        #endregion

        #region Delete
        public async Task<ActionResult> ViewConfirmDelete(SliderViewModel model)
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
        public async Task<ActionResult> Delete(byte id)
        {
            try
            {
                //Call API Provider
                string strUrl = APIProvider.APIGenerator(this, this.RouteData.Values["action"].ToString(), id);
                var model = await APIProvider.Get<SliderViewModel>(controllerName + strUrl);

                string apiUrl = APIProvider.APIGenerator(controllerName, APIConstant.ACTION_DELETE);
                var result = await APIProvider.Authorize_DynamicTransaction<SliderViewModel, bool>(model, _userSession.BearerToken, apiUrl, APIConstant.API_Resource_CMS, ARS.IgnoredARS);

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
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return View();
            }
        }

        #endregion

        #region Check exist
        //[HttpPost]
        //[AllowAnonymous]
        //public JsonResult CheckExist(string title, byte id)
        //{

        //    var isExist = APIHelper.Get<bool>(apiUrl + "/" + id + "?title=" + title);

        //    return Json(!isExist, JsonRequestBehavior.AllowGet);
        //}
        #endregion
    }
}