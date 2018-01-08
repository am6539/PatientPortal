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
    public class WorkflowRepoImpl : IWorkflowRepo
    {
        /// <summary>
        /// declare variables
        /// </summary>
        IWorkflow _workflow;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="workflow"></param>
        public WorkflowRepoImpl(IWorkflow workflow)
        {
            this._workflow = workflow;
        }

        public async Task<Workflow> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _workflow.SingleQuery(para);
        }
        public async Task<IEnumerable<Workflow>> Query(Dictionary<string, dynamic> para)
        {
            return await _workflow.Query(para);
        }
        public async Task<bool> Transaction(Workflow data, char action)
        {
            return await _workflow.Transaction(data, action);
        }
        public async Task<bool> CheckExist(Dictionary<string, dynamic> para)
        {
            return await _workflow.CheckExist(para);
        }
        public async Task<bool> CheckIsUsed(Dictionary<string, dynamic> para)
        {
            return await _workflow.CheckIsUsed(para);
        }
    }
}
