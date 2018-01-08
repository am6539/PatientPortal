using PatientPortal.Domain.Models.SPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.IRepository.SPA
{
    public interface IScheduleRepo
    {
        Task<List<Schedule>> QueryScheduleExamine(Dictionary<string, object> param);
        Task<Schedule> GetScheduleExamine(Dictionary<string, object> param);
    }
}
