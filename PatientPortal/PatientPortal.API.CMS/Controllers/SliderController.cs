using System.Collections.Generic;
using System.Web.Http;
using PatientPortal.IRepository.CMS;
using AutoMapper;
using PatientPortal.API.CMS.ViewModels;
using PatientPortal.Domain.Utilities;
using PatientPortal.Provider.Models;
using System.Threading.Tasks;
using PatientPortal.API.CMS.Models;

namespace PatientPortal.API.CMS.Controllers
{
    [AuthorizeRoles]
    public class SliderController : ApiController
    {
        private readonly ISliderRepo _slider;
        public SliderController(ISliderRepo slider)
        {
            this._slider = slider;
        }


        // GET api/values
        ///[Filters.DeflateCompression]
        public async Task<List<SliderViewModel>> Get()
        {
            IList<string> list = new List<string> { "id" };
            var para = APIProvider.APIDefaultParameter(list, 0);

            //Mapping
            var source =  await _slider.Query(para);
            List<SliderViewModel> dest = Mapper.Map<List<SliderViewModel>>(source);

            return dest;
        }

        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Category view model</returns>
        // GET api/values/5
        public async Task<SliderViewModel> GetById(short id)
        {
            var list = this.RequestContext.RouteData.Values.Keys;
            var para = APIProvider.APIGeneratorParameter(list, id);

            var source = await _slider.SingleQuery(para);
            SliderViewModel dest = Mapper.Map<SliderViewModel>(source);
            return dest;
        }

        /// <summary>
        /// Action: Insert/Update/Delete 
        /// </summary>
        /// <param name="categoryModel">object "model"</param>
        /// <param name="action">Action: 'I' - Insert; 'U'- Update; 'D'- Delete</param>
        /// <returns>Result: Success- true; Fail- false</returns>
        [HttpPost]
        public async Task<bool> Transaction(SliderViewModel model, char action)
        {
            var obj = Mapper.Map<Domain.Models.CMS.Slider>(model);
            return await _slider.Transaction(obj, action);
        }
    }
}
