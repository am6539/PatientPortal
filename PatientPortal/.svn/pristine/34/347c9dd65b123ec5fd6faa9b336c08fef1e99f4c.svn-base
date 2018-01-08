using System;
using System.Collections.Generic;
using System.Linq;
using PatientPortal.Domain.Models.CORE;
using PatientPortal.DataAccess.Repo.Core;
using System.Threading.Tasks;
using PatientPortal.DataAccess.Repo.Wrapper;
using PatientPortal.Domain.Common;
using PatientPortal.Domain.LogManager;
using PatientPortal.Domain.Models.CORE.Report;

namespace PatientPortal.DataAccess.CORE
{
    public class AppointmentImpl : IAppointment
    {
        private readonly IAdapterPattern _adapterPattern;
        public AppointmentImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }

        public async Task<List<AppointmentEdit>> Query(Dictionary<string, object> param)
        {
            try
            {
                var data = await _adapterPattern.ExecuteQuery<AppointmentEdit>(param, "usp_Appointment", DataConfiguration.instanceCore);

                return data.ToList();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }

        /// <summary>
        /// Get Appointments
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<List<RPAppointment>> GetRPAppointment(Dictionary<string, object> param)
        {
            try
            {
                var data = await _adapterPattern.ExecuteQuery<RPAppointment>(param, "usp_Appointment_Dashboard", DataConfiguration.instanceCore);
                return data.ToList();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }

        /// <summary>
        /// Get Schedule
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<List<Schedule>> GetScheduleExamine(Dictionary<string, object> param)
        {
            try
            {
                var data = await _adapterPattern.ExecuteQuery<Schedule>(param, "usp_ScheduleExamine", DataConfiguration.instanceCore);
                return data.ToList();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }

        public async Task<int> Transaction(AppointmentEdit data, char action)
        {
            try
            {
                var val = await _adapterPattern.SingleTransaction<AppointmentEdit, int>(data, "usp_Appointment_Transaction", action, DataConfiguration.instanceCore);
                return val;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return 0;
            }
        }
    }
}
