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
    public class WorkflowStateImpl : IWorkflowState
    {
        private readonly IAdapterPattern _adapterPattern;

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="adapterPattern"></param>
        public WorkflowStateImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }


        /// <summary>
        /// Get by condition
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<WorkflowState> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<WorkflowState>(para, "usp_WorkflowState");
        }

        /// <summary>
        /// Get all 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<WorkflowState>> Query(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.ExecuteQuery<WorkflowState>(para, "usp_WorkflowState");
        }

        /// <summary>
        /// Transaction
        /// </summary>
        /// <param name="data"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task<bool> Transaction(WorkflowStateEdit data, char action)
        {
            return await _adapterPattern.SingleTransaction<WorkflowStateEdit, bool>(data, "usp_WorkflowState_Transaction", action);
        }

        /// <summary>
        /// Check exist item
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<bool> CheckExist(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<bool>(para, "usp_WorkflowState_CheckExistName");
        }

        /// <summary>
        /// Check is used
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<bool> CheckIsUsed(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<bool>(para, "usp_WorkflowState_CheckIsUsed");
        }
    }
}
