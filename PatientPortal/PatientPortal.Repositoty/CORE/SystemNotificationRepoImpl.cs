using PatientPortal.DataAccess.Repo.CORE;
using PatientPortal.Domain.Models.CORE.OM;
using PatientPortal.IRepository.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Repositoty.CORE
{
    public class SystemNotificationRepoImpl: ISystemNotificationRepo
    {
        private readonly ISystemNotification _iSystemNotification;

        public SystemNotificationRepoImpl(ISystemNotification iSystemNotification)
        {
            this._iSystemNotification = iSystemNotification;
        }

        public Task<Tuple<IEnumerable<SystemNotification>, int>> QueryPaging(Dictionary<string, dynamic> para)
        {
            return _iSystemNotification.QueryPaging(para);
        }

        public Task<SystemNotification> SingleQuery(Dictionary<string, dynamic> para)
        {
            return _iSystemNotification.SingleQuery(para);
        }

        public Task<bool> Transaction(SystemNotification data, char action)
        {
            return _iSystemNotification.Transaction(data, action);
        }
    }
}
