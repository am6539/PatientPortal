using System.Collections.Generic;
using System.Web.Http;
using PatientPortal.IRepository.CORE;
using AutoMapper;
using PatientPortal.API.Core.Models;
using PatientPortal.Domain.Utilities;
using PatientPortal.Provider.Models;
using System.Threading.Tasks;

namespace PatientPortal.API.Core.Controllers
{
    [AuthorizeRoles]
    public class DepartmentServicesController : ApiController
    {
        private readonly IDepartmentServicesRepo _departmentServices;
        public DepartmentServicesController(IDepartmentServicesRepo departmentServices)
        {
            this._departmentServices = departmentServices;
        }


        // GET api/values
        ///[Filters.DeflateCompression]
        public async Task<List<DepartmentServicesViewModel>> Get(short departmentId)
        {
            //Mapping
            IList<string> list = new List<string> { "id", "departmentId" };
            var para = APIProvider.APIDefaultParameter(list, 0, departmentId);

            var source = await _departmentServices.Query(para);
            List<DepartmentServicesViewModel> dest = Mapper.Map<List<DepartmentServicesViewModel>>(source);

            return dest;
        }

        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Category view model</returns>
        // GET api/values/5
        public async Task<DepartmentServicesViewModel> GetById(short id, short departmentId)
        {
            IList<string> list = new List<string> { "id", "departmentId" };
            var para = APIProvider.APIDefaultParameter(list, id, departmentId);

            var source = await _departmentServices.SingleQuery(para);
            DepartmentServicesViewModel dest = Mapper.Map<DepartmentServicesViewModel>(source);
            return dest;
        }

        /// <summary>
        /// Action: Insert/Update/Delete 
        /// </summary>
        /// <param name="model">object "model"</param>
        /// <param name="action">Action: 'I' - Insert; 'U'- Update; 'D'- Delete</param>
        /// <returns>Result: Success- true; Fail- false</returns>
        [HttpPost]
        public async Task<bool> Transaction(DepartmentServicesViewModel model, char action)
        {
            var obj = Mapper.Map<Domain.Models.CORE.DepartmentServices>(model);
            return await _departmentServices.Transaction(obj, action);
        }

        /// <summary>
        /// Check name is existed
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns>If existed: true - else: false</returns>
        [HttpGet]
        public async Task<bool> CheckExist(string name, short id, short departmentId)
        {
            //var list = this.RequestContext.RouteData.Values.Keys;
            var list = new List<string> { nameof(name), nameof(id), nameof(departmentId) };
            var para = APIProvider.APIGeneratorParameter(list,name, id, departmentId);

            return await _departmentServices.CheckExist(para);
        }
    }
}
