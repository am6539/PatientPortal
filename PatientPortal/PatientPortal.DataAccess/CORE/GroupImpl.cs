using PatientPortal.DataAccess.Repo.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using PatientPortal.DataAccess.Dapper;
using Dapper;
using PatientPortal.Domain.Utilities;
using PatientPortal.Domain.Models.CORE;
using PatientPortal.DataAccess.Repo.Wrapper;
using PatientPortal.Domain.Common;
using PatientPortal.Domain.LogManager;

namespace PatientPortal.DataAccess.CORE
{
    public class GroupImpl : IGroup
    {
        private readonly IAdapterPattern _adapterPattern;

        public GroupImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }

        /// <summary>
        /// Get List Group
        /// </summary>
        /// <param name="param">Dictionary</param>
        /// <returns>List Group</returns>
        public async Task<List<Group>> Query(Dictionary<string, object> param)
        {
            try
            {
                var data = await _adapterPattern.ExecuteQuery<Group>(param, "usp_Group", DataConfiguration.instanceCore);
                return data.ToList();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }

        /// <summary>
        /// Transaction of Group
        /// </summary>
        /// <param name="data">Object Group</param>
        /// <param name="action">I: Insert, U:Update, D: Delete</param>
        /// <returns>true/false</returns>
        public async Task<int> Transaction(Group data, char action)
        {
            var val = await _adapterPattern.SingleTransaction<Group, int>(data, "usp_Group_Transaction", action, DataConfiguration.instanceCore);
            return val;
        }
    }
}
