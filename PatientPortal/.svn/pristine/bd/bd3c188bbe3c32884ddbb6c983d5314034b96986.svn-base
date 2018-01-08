using System.Collections.Generic;
using System.Web.Http;
using PatientPortal.IRepository.CMS;
using AutoMapper;
using PatientPortal.API.CMS.ViewModels;
using PatientPortal.Provider.Models;
using System.Threading.Tasks;
using PatientPortal.API.CMS.Models;

namespace PatientPortal.API.CMS.Controllers
{
    [AuthorizeRoles]
    public class ConfigurationController : ApiController
    {
        private readonly IConfigurationRepo _config;
        public ConfigurationController(IConfigurationRepo config)
        {
            this._config = config;
        }


        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Category view model</returns>
        // GET api/values/5
        public async Task<CMSConfigurationViewModel> GetById(byte id)
        {
            var list = this.RequestContext.RouteData.Values.Keys;
            var para = APIProvider.APIGeneratorParameter(list, id);

            var source = await _config.SingleQuery(para);
            CMSConfigurationViewModel dest = Mapper.Map<CMSConfigurationViewModel>(source);
            if (dest == null)
                dest = new CMSConfigurationViewModel();
            return dest;
        }

        /// <summary>
        /// Action: Insert/Update/Delete 
        /// </summary>
        /// <param name="categoryModel">object "model"</param>
        /// <param name="action">Action: 'I' - Insert; 'U'- Update; 'D'- Delete</param>
        /// <returns>Result: Success- true; Fail- false</returns>
        [HttpPost]
        public async Task<bool> Transaction(CMSConfigurationViewModel model, char action)
        {
            var obj = Mapper.Map<Domain.Models.CMS.CMSConfiguration>(model);
            return await _config.Transaction(obj, action);
        }
    }
}
