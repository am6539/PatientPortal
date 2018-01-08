using PatientPortal.Domain.Models.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.Repo.CORE
{
    public interface ISchedule
    {
        Task<List<Schedule>> Query(Dictionary<string, object> param);
        Task<Schedule> SingleQuery(Dictionary<string, object> param);
        Task<int> Transaction(Schedule data, char action);
    }
}
