using PatientPortal.IRepository.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CORE;
using PatientPortal.DataAccess.Repo.Core;
using PatientPortal.Domain.Models.CORE.Report;

namespace PatientPortal.Repositoty.CORE
{
    public class AppointmentRepoImpl : IAppointmentRepo
    {
        private readonly IAppointment _appointment;
        public AppointmentRepoImpl(IAppointment appointment)
        {
            this._appointment = appointment;
        }

        public async Task<List<AppointmentEdit>> Query(Dictionary<string, object> param)
        {
            return await _appointment.Query(param);
        }

        public Task<List<RPAppointment>> GetRPAppointment(Dictionary<string, object> param)
        {
            return _appointment.GetRPAppointment(param);
        }

        public Task<List<Schedule>> GetScheduleExamine(Dictionary<string, object> param)
        {
            return _appointment.GetScheduleExamine(param);
        }

        public Task<int> Transaction(AppointmentEdit data, char action)
        {
            return _appointment.Transaction(data, action);
        }
    }
}
