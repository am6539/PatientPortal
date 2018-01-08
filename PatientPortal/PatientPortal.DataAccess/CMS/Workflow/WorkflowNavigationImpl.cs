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
    public class WorkflowNavigationImpl : IWorkflowNavigation
    {
        private readonly IAdapterPattern _adapterPattern;

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="adapterPattern"></param>
        public WorkflowNavigationImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }

        /// <summary>
        /// Get by condition
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<WorkflowNavigation> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<WorkflowNavigation>(para, "usp_WorkflowNavigation");
        }

        /// <summary>
        /// Get all 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<WorkflowNavigation>> Query(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.ExecuteQuery<WorkflowNavigation>(para, "usp_WorkflowNavigation");
        }

        /// <summary>
        /// Transaction
        /// </summary>
        /// <param name="data"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task<bool> Transaction(WorkflowNavigationEdit data, char action)
        {
            return await _adapterPattern.SingleTransaction<WorkflowNavigationEdit, bool>(data, "usp_WorkflowNavigation_Transaction", action);
        }
    }
}
