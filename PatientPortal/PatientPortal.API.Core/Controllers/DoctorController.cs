using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using PatientPortal.IRepository.CORE;
using PatientPortal.Domain.Models.CORE;
using PatientPortal.Provider.Models;
using PatientPortal.API.Core.Models;

namespace PatientPortal.API.Core.Controllers
{
    [RoutePrefix("api/Doctor")]
    [AuthorizeRoles]
    public class DoctorController : ApiController
    {
        private readonly IDoctorProfileRepo _doctor;

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="offeradvise"></param>
        public DoctorController(IDoctorProfileRepo doctor)
        {
            this._doctor = doctor;
        }

        #region GET
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        [AuthorizeRoles]
        [HttpGet]
        public async Task<List<DoctorProfileViewModel>> Get()
        {
            List<string> list = new List<string> { "userid" };
            var para = APIProvider.APIDefaultParameter(list, string.Empty);

            var source = await _doctor.Query(para);
            var dest = Mapper.Map<List<DoctorProfileViewModel>>(source);

            return dest;
        }


        /// <summary>
        /// Filter by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<DoctorProfileViewModel> Get(string id)
        {
            List<string> list = new List<string> { "userid" };
            var para = APIProvider.APIGeneratorParameter(list, id);

            var source = await _doctor.SingleQuery(para);
            var dest = Mapper.Map<DoctorProfileViewModel>(source);

            return (dest == null ? new DoctorProfileViewModel() : dest);
        }

        #endregion

        #region POST

        /// <summary>
        /// Transaction data: Insert/Update/Delete
        /// </summary>
        /// <param name="model"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> Transaction(DoctorProfileEditModel model, char action)
        {
            var data = Mapper.Map<DoctorProfileEdit>(model);
            return await _doctor.Transaction(data, action);
        }
        #endregion
    }
}