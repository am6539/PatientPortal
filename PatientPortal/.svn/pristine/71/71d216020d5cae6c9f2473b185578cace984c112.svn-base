using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CORE;
using PatientPortal.Domain.Utilities;
using System.Transactions;
using PatientPortal.DataAccess.Dapper;
using Dapper;
using PatientPortal.DataAccess.Repo.CORE;
using PatientPortal.DataAccess.Repo.Wrapper;
using PatientPortal.Domain.Common;

namespace PatientPortal.DataAccess.CORE
{
    public class DepartmentImpl : IDepartment
    {
        private readonly IAdapterPattern _adapterPattern;

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="adapterPattern"></param>
        public DepartmentImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }

        /// <summary>
        /// Get by condition
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<Department> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<Department>(para, "usp_Department", DataConfiguration.instanceCore);
        }

        /// <summary>
        /// Get all 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Department>> Query(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.ExecuteQuery<Department>(para, "usp_Department", DataConfiguration.instanceCore);
        }

        /// <summary>
        /// Transaction
        /// </summary>
        /// <param name="data"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task<bool> Transaction(Department data, char action)
        {
            return await _adapterPattern.SingleTransaction<Department, bool>(data, "usp_Department_Transaction", action, DataConfiguration.instanceCore);
        }

        /// <summary>
        /// Check exist item
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<bool> CheckExist(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<bool>(para, "usp_Department_CheckExistName", DataConfiguration.instanceCore);
        }
    }
}
