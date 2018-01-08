using PatientPortal.IRepository.SPA;
using System.Collections.Generic;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.SPA;
using PatientPortal.DataAccess.Repo.SPA;

namespace PatientPortal.Repositoty.SPA
{
    public class AppointmentLogRepoImpl : IAppointmentLogRepo
    {
        private IAppointmentLog _iAppointment;
    
        public AppointmentLogRepoImpl(IAppointmentLog iAppointment)
        {
            this._iAppointment = iAppointment;
        }

        public async Task<List<Schedule>> GetScheduleExamine(Dictionary<string, object> param)
        {
            return await _iAppointment.GetScheduleExamine(param);
        }

        public async Task<bool> Transaction(AppointmentLogEdit data, char action)
        {
            return await _iAppointment.Transaction(data, action);
        }
    }
}
