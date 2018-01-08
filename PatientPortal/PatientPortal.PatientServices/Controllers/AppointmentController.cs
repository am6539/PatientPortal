using PatientPortal.PatientServices.Models;
using PatientPortal.Provider.Common;
using PatientPortal.Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using PatientPortal.Domain.LogManager;
using PatientPortal.Utility.Application;
using PatientPortal.Domain.Models.AUTHEN;
using System.Web;
using static PatientPortal.Utility.Application.ApplicationGenerator;
using PatientPortal.Domain.Models.CORE.Report;
using WebMarkupMin.AspNet4.Mvc;
using PatientPortal.PatientServices.Common;
using static PatientPortal.PatientServices.Common.ValueConstant;

namespace PatientPortal.PatientServices.Controllers
{
    [Authorize]
    [AppHandleError]
    //[CompressContent]
    //[MinifyHtml]
    public class AppointmentController : Controller
    {
        #region declare variable
        private static string controllerName = "AppointmentLog";
        private static string controllerUser = "User";
        private static string controllerSchedule = "Schedule";
        private static string controllerDoctor = "Doctor";
        private readonly IUserSession _userSession;
        #endregion

        public AppointmentController(IUserSession userSession)
        {
            _userSession = userSession;
        }

        // GET: Appointment
        public async Task<ActionResult> Index()
        {
            try
            {
                return View();
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
        /// Init appointment
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Make()
        {
            //get list of doctors
            string search = "";
            var doctorList = await GetListDoctor(search);
            ViewBag.Doctors = doctorList;

            //Init appointment
            //var userId = GetUserId();
            var appointmentModel = new AppointmentLogEditModel() { PatientId = _userSession.UserId };
            return View(appointmentModel);
        }

        /// <summary>
        /// View List of doctor
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public async Task<ActionResult> ViewDoctorList(string search)
        {
            if(search == "searchText")
            {
                search = null;
            }
            var doctorSchedules = new List<UserViewModel>();
            //get list doctor
            var doctors = await GetListDoctor(search);
            if (doctors == null) doctors = new List<UserViewModel>();

            return PartialView("_DoctorList", doctors);
        }


        /// <summary>
        /// View Doctor detail
        /// </summary>
        /// <param name="doctorId"></param>
        /// <returns></returns>
        public async Task<ActionResult> DoctorDetail(string doctorId)
        {
            string Id = doctorId;
            var doctor = await GetDoctorDetail(Id);
            if (doctor == null) doctor = new DoctorProfileViewModel();
            return PartialView("_QuickViewDoctorProfile", doctor);
        }

        /// <summary>
        /// View doctor detail & schedule
        /// </summary>
        /// <param name="doctorId"></param>
        /// <returns></returns>
        public async Task<ActionResult> DoctorSchedule(string doctorId)
        {
            //get doctor
            var token = _userSession.BearerToken;
            string id = doctorId;
            var doctor = await GetDoctorDetail(id);
            if (doctor == null) doctor = new DoctorProfileViewModel();

            var model = new ScheduleUserViewModel();

            //get schedule of doctor
            var userId = doctor.UserId;
            var start = DateTime.Now;
            var end = DateTime.Now.AddDays(2);
            string apiUrlSchedule = APIProvider.APIGenerator(controllerSchedule, new List<string> { nameof(userId),
                nameof(start), nameof(end) }, true, userId, start.ToString("yyyy-MM-dd"), end.ToString("yyyy-MM-dd"));
            var schedule = await APIProvider.Authorize_Get<List<ScheduleViewModel>>(token, apiUrlSchedule, APIConstant.API_Resource_CORE);
            
            model.DoctorProfileViewModel = doctor;
            model.lstScheduleViewModel = schedule;
            
            return PartialView("_DoctorDetail", model);
        }

        /// <summary>
        /// View Appoiment
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<ActionResult> AppointmentPartial(string Id)
        {
            //var userId = GetUserId();
            var appointment = new AppointmentLogEditModel() { PatientId = _userSession.UserId };
            appointment.PhysicianId = Id;

            string search = "";
            var doctorList = await GetListDoctor(search);
            ViewBag.Doctors = doctorList;

            return PartialView("_Appointment", appointment);
        }

        /// <summary>
        /// information of patient that ordered an appointment
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<ActionResult> InfoOrder(string patientId)
        {
            var token = _userSession.BearerToken;
            string id = patientId; 
            string apiUrl = APIProvider.APIGenerator(controllerUser, new List<string> { nameof(id) }, false, id);
            var patient = await APIProvider.Authorize_Get<UserViewModel>(token, apiUrl, APIConstant.API_Resource_CORE);

            return PartialView("_InfoOrder", patient);
        }

        /// <summary>
        /// confirm appointment
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> ConfirmAppointment(AppointmentLogEditModel model)
        {
            if(model.PhysicianId == null)
            {
                ModelState["PhysicianId"].Errors.Clear();
            }
            if (ModelState.IsValid)
            {
                TimeSpan time = TimeSpan.Parse(model.TimeString);
                model.Time = (int)time.TotalMinutes;
                model.Status = (byte)AppointmentStatus.Create;

                string search = "";
                var doctorList = await GetListDoctor(search);

                ViewBag.Doctors = doctorList;
                model.PhysicianIdTemp = model.PhysicianId;
            }
            else
            {
                string search = "";
                var doctorList = await GetListDoctor(search);

                ViewBag.Doctors = doctorList;
            }
            return PartialView("_Appointment", model);
        }

        /// <summary>
        /// Save an appointment is confirmed
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> ApplyAppointment(AppointmentLogEditModel model)
        {
            TimeSpan time = TimeSpan.Parse(model.TimeString);
            model.Time = (int)time.TotalMinutes;
            model.PhysicianId = model.PhysicianIdTemp;
            if(model.PhysicianId == null)
            {
                model.PhysicianId = "";
            }
            ModelState["PhysicianId"].Errors.Clear();

            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid();
                model.Status = (byte)AppointmentStatus.Create;
                var result = await Save(model, APIConstant.ACTION_INSERT);
                if(result)
                {
                    TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.SUCCESS_APPOINTMENT, ApplicationGenerator.GeneralActionMessage(ValueConstant.ACTION_APPOINMENT, ApplicationGenerator.TypeResult.SUCCESS_APPOINTMENT));
                    return RedirectToAction("Make");
                }
                else
                {
                    string search = "";
                    var doctorList = await GetListDoctor(search);

                    ViewBag.Doctors = doctorList;
                    return PartialView("_Appointment", model);
                }
            }
            else
            {
                string search = "";
                var doctorList = await GetListDoctor(search);

                ViewBag.Doctors = doctorList;
                return PartialView("_Appointment", model);
            }
        }

        /// <summary>
        /// Get default doctor after search by tags
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetDefaultDoctorByTag(string search)
        {
            var list = await GetListDoctor(search) as List<UserViewModel>;
            var data = list.FirstOrDefault();
            if (data == null)
                data = new UserViewModel() { Id = string.Empty };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Get examine time of a doctor(valid examine time of a doctor)
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="startTime"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetExamineTime(string userId, long startTime)
        {
            var token = _userSession.BearerToken;
            DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime start = date.AddMilliseconds(startTime).ToLocalTime();
            //var start = Convert.ToDateTime(startTime);
            var lstAvaiableTime = new List<string>();

            if (start == DateTime.MinValue && start == DateTime.MinValue)
            {
                start = DateTime.Now.AddDays(-2);
            }
            //controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string apiUrlSchedule = APIProvider.APIGenerator(controllerName, new List<string> { nameof(userId),
                nameof(start) }, true, userId, start.ToString("yyyy-MM-dd"));
            var schedule = await APIProvider.Authorize_Get<List<ScheduleViewModel>>(token, apiUrlSchedule, APIConstant.API_Resource_CORE, ARS.Detail);
            if (schedule.Count > 0)
            {
                var timeSchedule = schedule.FirstOrDefault();
                lstAvaiableTime.Add(timeSchedule.Start.Hour.ToString() + ":" + timeSchedule.Start.Minute.ToString());
                while (timeSchedule.Start <= timeSchedule.End)
                {
                    timeSchedule.Start = timeSchedule.Start.AddMinutes(15);
                    lstAvaiableTime.Add(timeSchedule.Start.Hour.ToString() + ":" + timeSchedule.Start.Minute.ToString());
                }
            }
            return Json(lstAvaiableTime, JsonRequestBehavior.AllowGet);
        }

        #region PRIVATE METHOD

        //get userId current login
        //private string GetUserId()
        //{
        //    var identity = Thread.CurrentPrincipal.Identity;
        //    if (identity == null && HttpContext.User != null)
        //    {
        //        identity = HttpContext.User.Identity;
        //    }
        //    return identity.GetUserId();
        //}

        /// <summary>
        /// Get List of doctor
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        private async Task<List<UserViewModel>> GetListDoctor(string search)
        {
            var token = _userSession.BearerToken;
            string action = "GetUserHaveScheduleExamine";
            string apiUrl = APIProvider.APIGenerator(controllerUser, action, new List<string> { nameof(search) }, true, search);
            var list = await APIProvider.Authorize_Get<List<UserViewModel>>(token, apiUrl, APIConstant.API_Resource_CORE, ARS.Get);
            if (list == null) list = ApplicationGenerator.GetObject<List<UserViewModel>>();

            return list;
        }

        /// <summary>
        /// Get doctor by Id
        /// </summary>
        /// <param name="doctorId"></param>
        /// <returns></returns>
        private async Task<DoctorProfileViewModel> GetDoctorDetail(string doctorId)
        {
            var token = _userSession.BearerToken;
            string id = doctorId;
            string apiUrl = APIProvider.APIGenerator(controllerDoctor, new List<string> { nameof(id) }, false, id);
            var doctor = await APIProvider.Authorize_Get<DoctorProfileViewModel>(token, apiUrl, APIConstant.API_Resource_CORE, ARS.Detail);
            if (doctor == null) doctor = ApplicationGenerator.GetObject<DoctorProfileViewModel>();
            return doctor;
        }

        /// <summary>
        /// Save appointment
        /// </summary>
        /// <param name="model"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        private async Task<bool> Save(AppointmentLogEditModel model, string action)
        {
            bool result = false;
            try
            {
                var token = _userSession.BearerToken;
                string strUrl = APIProvider.APIGenerator(controllerName, APIConstant.ACTION_INSERT);
                result = await APIProvider.Authorize_DynamicTransaction<AppointmentLogEditModel, bool>(model, token, strUrl, APIConstant.API_Resource_CORE, ARS.Insert);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                Logger.LogError(ex);
            }
            return result;
        }

        #endregion
    }
}