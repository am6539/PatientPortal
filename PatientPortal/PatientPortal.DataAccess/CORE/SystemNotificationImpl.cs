using PatientPortal.DataAccess.Repo.CORE;
using PatientPortal.DataAccess.Repo.Wrapper;
using PatientPortal.Domain.Common;
using PatientPortal.Domain.LogManager;
using PatientPortal.Domain.Models.CORE.OM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.CORE
{
    public class SystemNotificationImpl: ISystemNotification
    {
        private readonly IAdapterPattern _adapterPattern;
        public SystemNotificationImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }

        public async Task<Tuple<IEnumerable<SystemNotification>, int>> QueryPaging(Dictionary<string, dynamic> para)
        {
            Tuple<IEnumerable<SystemNotification>, int> data = await _adapterPattern.ExecuteQueryOut<SystemNotification>(para, "usp_SystemNotification", "totalItem", 2);
            return data;
        }

        public async Task<SystemNotification> SingleQuery(Dictionary<string, dynamic> para)
        {
            try
            {
                var data = await _adapterPattern.SingleExecuteQuery<SystemNotification>(para, "usp_SystemNotification", DataConfiguration.instanceCore);
                return data;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }

        public async Task<bool> Transaction(SystemNotification data, char action)
        {
            var val = await _adapterPattern.SingleTransaction<SystemNotification, bool>(data, "usp_SystemNotification_Transaction", action, DataConfiguration.instanceCore);
            return val;
        }

    }
}
