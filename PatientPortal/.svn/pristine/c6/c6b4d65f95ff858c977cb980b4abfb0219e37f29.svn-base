using PatientPortal.DataAccess.Repo.SPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.SPA;
using PatientPortal.DataAccess.Repo.Wrapper;
using PatientPortal.Domain.LogManager;
using PatientPortal.Domain.Common;

namespace PatientPortal.DataAccess.SPA
{
    public class AppointmentLogImpl : IAppointmentLog
    {
        private readonly IAdapterPattern _adapterPattern;

        public AppointmentLogImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }

        public async Task<List<Schedule>> GetScheduleExamine(Dictionary<string, object> param)
        {
            try
            {
                var data = await _adapterPattern.ExecuteQuery<Schedule>(param, "usp_spa_ScheduleExamine", DataConfiguration.instanceCore);
                return data.ToList();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }

        public async Task<List<User>> GetUserHaveScheduleExamine(Dictionary<string, object> param)
        {
            try
            {
                var data = await _adapterPattern.ExecuteQuery<User>(param, "usp_spa_User_HasScheduleExamine", DataConfiguration.instanceCore);
                return data.ToList();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }

        public async Task<bool> Transaction(AppointmentLogEdit data, char action)
        {
            try
            {
                var val = await _adapterPattern.SingleTransaction<AppointmentLogEdit, bool>(data, "usp_AppointmentLog_Transaction", action, DataConfiguration.instanceCore);
                return val;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return false;
            }
        }
    }
}
