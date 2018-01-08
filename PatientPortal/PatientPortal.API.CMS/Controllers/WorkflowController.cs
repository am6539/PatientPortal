using AutoMapper;
using PatientPortal.API.CMS.Models;
using PatientPortal.API.CMS.ViewModels;
using PatientPortal.IRepository.CMS;
using PatientPortal.Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PatientPortal.API.CMS.Controllers
{
    [AuthorizeRoles]
    public class WorkflowController : ApiController
    {
        /// <summary>
        /// Declare variable
        /// </summary>
        private readonly IWorkflowRepo _workflow;
        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="workflow"></param>
        public WorkflowController(IWorkflowRepo workflow)
        {
            this._workflow = workflow;
        }

        #region API function

        /// <summary>
        /// Get all workflow
        /// </summary>
        /// <returns>List of WorkflowViewModel</returns>
        public async Task<List<WorkflowViewModel>> GetAll()
        {
            List<string> list = new List<string> { "id" };
            var para = APIProvider.APIDefaultParameter(list, 0);

            var source = await _workflow.Query(para);
            List<WorkflowViewModel> dest = Mapper.Map<List<WorkflowViewModel>>(source);

            return dest;
        }

        /// <summary>
        /// Action: Insert/Update/Delete workflow
        /// </summary>
        /// <param name="workflowModel">object "WorkflowViewModel"</param>
        /// <param name="action">Action: 'I' - Insert; 'U'- Update; 'D'- Delete</param>
        /// <returns>Result: Success- true; Fail- false</returns>
        [HttpPost]
        public async Task<bool> Transaction(WorkflowViewModel workflowModel, char action)
        {
            var obj = Mapper.Map<Domain.Models.CMS.Workflow>(workflowModel);
            return await _workflow.Transaction(obj, action);
        }
        #endregion

        [HttpGet]
        public async Task<bool> CheckExist(string name, byte id)
        {
            List<string> list = new List<string> { nameof(name), nameof(id) };
            var para = APIProvider.APIGeneratorParameter(list, name, id);

            return await _workflow.CheckExist(para);
        }

        public async Task<WorkflowViewModel> GetById(byte id    )
        {
            var list = this.RequestContext.RouteData.Values.Keys;
            var para = APIProvider.APIGeneratorParameter(list, id);

            var source = await _workflow.SingleQuery(para);
            WorkflowViewModel dest = Mapper.Map<WorkflowViewModel>(source);

            return dest;
        }

        [HttpGet]
        [Route("api/Workflow/CheckIsUsed/{id}")]
        public async Task<bool> CheckIsUsed(byte id)
        {
            var list = this.RequestContext.RouteData.Values.Keys;
            var para = APIProvider.APIGeneratorParameter(list, id);

            return await _workflow.CheckIsUsed(para);
        }
    }
}
