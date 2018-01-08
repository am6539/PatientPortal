using AutoMapper;
using PatientPortal.API.SPA.ViewModels;
using PatientPortal.Domain.Models.SPA;
using PatientPortal.IRepository.SPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PatientPortal.API.SPA.Controllers
{
    public class AppointmentController : ApiController
    {
        private readonly IAppointmentLogRepo _iAppointment;
        public AppointmentController(IAppointmentLogRepo iAppointment)
        {
            this._iAppointment = iAppointment;
        }

        [HttpPost]
        public async Task<bool> Transaction(AppointmentLogEditModel model, char action)
        {
            var data = Mapper.Map<AppointmentLogEdit>(model);
            return await _iAppointment.Transaction(data, action);
        }
    }
}
