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
    public class WorkflowNavigationRepoImpl : IWorkflowNavigationRepo
    {
        /// <summary>
        /// declare variables
        /// </summary>
        IWorkflowNavigation _workflowNavigation;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="language"></param>
        public WorkflowNavigationRepoImpl(IWorkflowNavigation workflowNavigation)
        {
            this._workflowNavigation = workflowNavigation;
        }

        public async Task<WorkflowNavigation> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _workflowNavigation.SingleQuery(para);
        }
        public async Task<IEnumerable<WorkflowNavigation>> Query(Dictionary<string, dynamic> para)
        {
            return await _workflowNavigation.Query(para);
        }
        public async Task<bool> Transaction(WorkflowNavigationEdit data, char action)
        {
            return await _workflowNavigation.Transaction(data, action);
        }
    }
}
