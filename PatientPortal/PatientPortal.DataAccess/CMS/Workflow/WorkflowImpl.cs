using PatientPortal.DataAccess.Repo.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CMS;
using System.Transactions;
using PatientPortal.DataAccess.Dapper;
using Dapper;
using PatientPortal.Domain.Utilities;
using PatientPortal.DataAccess.Repo.Wrapper;

namespace PatientPortal.DataAccess.CMS
{
    public class WorkflowImpl : IWorkflow
    {
        private readonly IAdapterPattern _adapterPattern;

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="adapterPattern"></param>
        public WorkflowImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }

        /// <summary>
        /// Get by condition
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<Workflow> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<Workflow>(para, "usp_Workflow");
        }

        /// <summary>
        /// Get all 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Workflow>> Query(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.ExecuteQuery<Workflow>(para, "usp_Workflow");
        }

        /// <summary>
        /// Transaction
        /// </summary>
        /// <param name="data"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task<bool> Transaction(Workflow data, char action)
        {
            return await _adapterPattern.SingleTransaction<Workflow, bool>(data, "usp_Workflow_Transaction", action);
        }

        /// <summary>
        /// Check exist item
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<bool> CheckExist(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<bool>(para, "usp_Workflow_CheckExistName");
        }

        /// <summary>
        /// Check is used
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<bool> CheckIsUsed(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<bool>(para, "usp_Workflow_CheckIsUsed");
        }
    }
}
