using PatientPortal.Domain.Models.CORE.OM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.IRepository.CORE
{
    public interface ISystemNotificationRepo
    {
        Task<Tuple<IEnumerable<SystemNotification>, int>> QueryPaging(Dictionary<string, dynamic> para);
        Task<SystemNotification> SingleQuery(Dictionary<string, dynamic> para);
        Task<bool> Transaction(SystemNotification data, char action);
    }
}
