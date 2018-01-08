using PatientPortal.IRepository.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CMS;
using PatientPortal.DataAccess.Repo.CMS;

namespace PatientPortal.Repositoty.CMS
{
    public class WorkflowStateRepoImpl : IWorkflowStateRepo
    {
        /// <summary>
        /// declare variables
        /// </summary>
        IWorkflowState _workflowState;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="workflowState"></param>
        public WorkflowStateRepoImpl(IWorkflowState workflowState)
        {
            this._workflowState = workflowState;
        }

        public async Task<WorkflowState> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _workflowState.SingleQuery(para);
        }
        public async Task<IEnumerable<WorkflowState>> Query(Dictionary<string, dynamic> para)
        {
            return await _workflowState.Query(para);
        }
        public async Task<bool> Transaction(WorkflowStateEdit data, char action)
        {
            return await _workflowState.Transaction(data, action);
        }
        public async Task<bool> CheckExist(Dictionary<string, dynamic> para)
        {
            return await _workflowState.CheckExist(para);
        }
        public async Task<bool> CheckIsUsed(Dictionary<string, dynamic> para)
        {
            return await _workflowState.CheckIsUsed(para);
        }
    }
}
