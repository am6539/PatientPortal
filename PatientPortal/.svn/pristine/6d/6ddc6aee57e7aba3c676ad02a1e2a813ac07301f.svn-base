using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CORE;
using System.Transactions;
using PatientPortal.DataAccess.Dapper;
using Dapper;
using PatientPortal.Domain.Utilities;
using PatientPortal.DataAccess.Repo.CORE;
using PatientPortal.DataAccess.Repo.Wrapper;
using PatientPortal.Domain.Common;
using PatientPortal.Domain.LogManager;

namespace PatientPortal.DataAccess.CORE
{
    public class OrganizationImpl : IOrganization
    {
        private readonly IAdapterPattern _adapterPattern;

        public OrganizationImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }

        /// <summary>
        /// Get Organization
        /// </summary>
        /// <param name="param">Dictionary</param>
        /// <returns>List Organization</returns>
        public async Task<List<Organization>> Query(Dictionary<string, object> param)
        {
            try
            {
                var data = await _adapterPattern.ExecuteQuery<Organization>(param, "usp_Organization", DataConfiguration.instanceCore);
                return data.ToList();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }

        /// <summary>
        /// Transaction of Organization
        /// </summary>
        /// <param name="data">Object Organization</param>
        /// <param name="action">I: Insert, U: Update, D: Delete</param>
        /// <returns>true/false</returns>
        public async Task<int> Transaction(Organization data, char action)
        {
            try
            {
                var val = await _adapterPattern.SingleTransaction<Organization, int>(data, "usp_Organization_Transaction", action, DataConfiguration.instanceCore);
                return val;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return 0;
            }
        }
    }
}
