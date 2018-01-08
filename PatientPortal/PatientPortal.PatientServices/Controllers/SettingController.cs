﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using PatientPortal.Domain.Utilities;
using PatientPortal.PatientServices.Common;
using PatientPortal.PatientServices.Models;
using PatientPortal.Provider.Common;
using PatientPortal.Provider.Models;
using PatientPortal.Utility.Application;
using System.Web;
using static PatientPortal.Utility.Application.ApplicationGenerator;
using PatientPortal.Domain.LogManager;
using PatientPortal.Domain.Models.AUTHEN;
using Microsoft.Owin.Security;
using WebMarkupMin.AspNet4.Mvc;

namespace PatientPortal.PatientServices.Controllers
{
    [Authorize]
    [AppHandleError]
    //[CompressContent]
    //[MinifyHtml]
    public class SettingController : Controller
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

        public SettingController(IUserSession userSession)
        {
            _userSession = userSession;
        }
        #endregion
        private static string controllerName = string.Empty;
        // GET: Setting
        public async Task<ActionResult> Index()
        {
            try
            {
                controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                var model = await APIProvider.Get<SettingViewModel>(controllerName + "/" + GlobalVariables.Id_Configuration, APIConstant.API_Resource_CORE);
                if (model == null)
                {
                    model = new SettingViewModel
                    {
                        Id = GlobalVariables.Id_Configuration,
                        Membership = true
                    };
                }
                var roles = new List<RoleViewModel>
            {
                new RoleViewModel {Id = 1, Name = "Chưa sử dụng"}
            };
                ViewBag.Roles = roles;
                if (model?.Keyword != null)
                {
                    ViewBag.Keywords = model.Keyword;
                }

                var startTime = TimeSpan.FromMinutes(model.AppointmentStartTime);
                var fromStartTimeString = startTime.ToString("hh':'mm");
                model.AppointmentStartTimeString = fromStartTimeString;

                var endTime = TimeSpan.FromMinutes(model.AppointmentEndTime);
                var fromEndTimeString = endTime.ToString("hh':'mm");
                model.AppointmentEndTimeString = fromEndTimeString;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Edit(SettingViewModel model)
        {
            var timeStart = TimeSpan.Parse(model.AppointmentStartTimeString);
            model.AppointmentStartTime = (int)timeStart.TotalMinutes;

            var timeEnd = TimeSpan.Parse(model.AppointmentEndTimeString);
            model.AppointmentEndTime = (int)timeEnd.TotalMinutes;

            if (ModelState.IsValid)
            {
                //Call API Provider 
                var strUrl = APIProvider.APIGenerator(controllerName, APIConstant.ACTION_UPDATE);
                var result = await APIProvider.DynamicTransaction<SettingViewModel, bool>(model, strUrl, APIConstant.API_Resource_CORE);
                if (result)
                {
                    TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.SUCCESS, ApplicationGenerator.GeneralActionMessage(ValueConstant.ACTION_UPDATE, ApplicationGenerator.TypeResult.SUCCESS));
                }
                else
                {
                    TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.FAIL, ApplicationGenerator.GeneralActionMessage(ValueConstant.ACTION_UPDATE, ApplicationGenerator.TypeResult.FAIL));
                }
            }
            else
            {
                TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.ERROR, ApplicationGenerator.GeneralActionMessage(ValueConstant.ACTION_UPDATE, ApplicationGenerator.TypeResult.ERROR));
            }
            return RedirectToAction("Index");
        }

        

    }
}