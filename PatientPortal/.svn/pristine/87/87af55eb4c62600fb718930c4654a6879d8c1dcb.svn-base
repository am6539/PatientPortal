using PatientPortal.IRepository.SPA;
using System.Collections.Generic;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.SPA;
using PatientPortal.DataAccess.Repo.SPA;
using System;

namespace PatientPortal.Repositoty.SPA
{
    public class ScheduleRepoImpl : IScheduleRepo
    {
        private ISchedule _iSchedule;

        public ScheduleRepoImpl(ISchedule iSchedule)
        {
            this._iSchedule = iSchedule;
        }

        public async Task<Schedule> GetScheduleExamine(Dictionary<string, object> param)
        {
            return await _iSchedule.GetScheduleExamine(param);
        }

        public async Task<List<Schedule>> QueryScheduleExamine(Dictionary<string, object> param)
        {
            return await _iSchedule.QueryScheduleExamine(param);
        }
    }
}
