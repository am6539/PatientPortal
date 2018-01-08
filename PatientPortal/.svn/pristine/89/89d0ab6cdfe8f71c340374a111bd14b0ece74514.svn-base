using PatientPortal.DataAccess.Repo.CORE;
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
using PatientPortal.DataAccess.Repo.Wrapper;
using PatientPortal.Domain.Common;
using PatientPortal.Domain.LogManager;

namespace PatientPortal.DataAccess.CORE
{
    public class UserRoleImpl : IUserRole
    {
        private readonly IAdapterPattern _adapterPattern;

        public UserRoleImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }

        /// <summary>
        /// Get UserRole
        /// </summary>
        /// <param name="param">Dictionary</param>
        /// <returns>List UserRole</returns>
        public async Task<List<UserRole>> Query(Dictionary<string, object> param)
        {
            try
            {
                var data = await _adapterPattern.ExecuteQuery<UserRole>(param, "usp_UserRole", DataConfiguration.instanceCore);
                return data.ToList();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }

        /// <summary>
        /// Transaction of UserRole
        /// </summary>
        /// <param name="data">Object UserRole</param>
        /// <param name="action">I: Insert, U: Update, D: Delete</param>
        /// <returns>true/false</returns>
        public async Task<int> Transaction(UserRole data, char action)
        {
            try
            {
                var val = await _adapterPattern.SingleTransaction<UserRole, int>(data, "usp_UserRole_Transaction", action, DataConfiguration.instanceCore);
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
