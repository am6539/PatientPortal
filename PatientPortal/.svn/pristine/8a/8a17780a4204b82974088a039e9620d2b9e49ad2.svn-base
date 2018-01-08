using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CMS;
using PatientPortal.Domain.Utilities;
using System.Transactions;
using PatientPortal.DataAccess.Dapper;
using Dapper;
using PatientPortal.DataAccess.Repo.CMS;
using PatientPortal.DataAccess.Repo.Wrapper;

namespace PatientPortal.DataAccess.CMS
{
    public class ConfigurationImpl : IConfiguration
    {
        private readonly IAdapterPattern _adapterPattern;

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="adapterPattern"></param>
        public ConfigurationImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }

        /// <summary>
        /// Get by condition
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<CMSConfiguration> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<CMSConfiguration>(para, "usp_Configuration");
        }

        /// <summary>
        /// Transaction
        /// </summary>
        /// <param name="data"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task<bool> Transaction(CMSConfiguration data, char action)
        {
            return await _adapterPattern.SingleTransaction<CMSConfiguration, bool>(data, "usp_Configuration_Transaction", action);
        }
    }
}
