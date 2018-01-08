using PatientPortal.DataAccess.Repo.CORE;
using System.Collections.Generic;
using System.Threading.Tasks;
using PatientPortal.DataAccess.Repo.Wrapper;
using PatientPortal.Domain.Common;
using PatientPortal.Domain.Models.CORE;

namespace PatientPortal.DataAccess.CORE
{
    public class SettingImpl : ISetting
    {
        private readonly IAdapterPattern _adapterPattern;

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="adapterPattern"></param>
        public SettingImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }

        /// <summary>
        /// Get by condition
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<Setting> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<Setting>(para, "usp_Setting", DataConfiguration.instanceCore);
        }

        /// <summary>
        /// Transaction
        /// </summary>
        /// <param name="data"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task<bool> Transaction(Setting data, char action)
        {
            return await _adapterPattern.SingleTransaction<Setting, bool>(data, "usp_Setting_Transaction", action, DataConfiguration.instanceCore);
        }
    }
}
