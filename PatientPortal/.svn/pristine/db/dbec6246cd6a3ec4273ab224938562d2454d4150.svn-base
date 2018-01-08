using PatientPortal.Domain.Models.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.Repo.CORE
{
    public interface IUser
    {
        Task<List<User>> Query(Dictionary<string, object> param);
        Task<User> SingleQuery(Dictionary<string, object> param);
        Task<int> Transaction(User data, char action);
        Task<List<User>> GetUserHaveScheduleExamine(Dictionary<string, object> param);
        Task<List<User>> GetUsersByGroupType(Dictionary<string, object> param);
        Task<string> GetUserId(Dictionary<string, object> param);
    }
}
