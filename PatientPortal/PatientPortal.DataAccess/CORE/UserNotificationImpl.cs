using PatientPortal.DataAccess.Repo.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CORE;
using PatientPortal.DataAccess.Repo.Wrapper;
using PatientPortal.Domain.LogManager;
using PatientPortal.Domain.Common;

namespace PatientPortal.DataAccess.CORE
{
    public class UserNotificationImpl : IUserNotification
    {
        private readonly IAdapterPattern _adapterPattern;

        public UserNotificationImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }

        public async Task<Tuple<IEnumerable<UserNotification>, int>> QueryPaging(Dictionary<string, dynamic> para)
        {
            Tuple<IEnumerable<UserNotification>, int> data = await _adapterPattern.ExecuteQueryOut<UserNotification>(para, "usp_UserNotification", "totalItem", 2);
            return data;
        }

        public async Task<UserNotification> SingleQuery(Dictionary<string, dynamic> para)
        {
            try
            {
                var data = await _adapterPattern.SingleExecuteQuery<UserNotification>(para, "usp_UserNotification", DataConfiguration.instanceCore);
                return data;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }

        public async Task<bool> Transaction(UserNotification data, char action)
        {
            var val = await _adapterPattern.SingleTransaction<UserNotification, bool>(data, "usp_UserNotification_Transaction", action, DataConfiguration.instanceCore);
            return val;
        }

        public async Task<bool> UpdateStatus(UserNotification data, char action)
        {
            var val = await _adapterPattern.SingleTransaction<UserNotification, bool>(data, "usp_UserNotification_UpdateStatus", action, DataConfiguration.instanceCore);
            return val;
        }
    }
}
