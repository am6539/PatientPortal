using AutoMapper;
using PatientPortal.API.Core.Models;
using PatientPortal.API.Core.Models.QA;
using PatientPortal.IRepository.CORE;
using PatientPortal.Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PatientPortal.API.Core.Controllers
{
    [AuthorizeRoles]
    public class QAController : ApiController
    {
        private readonly IQARepo _iQARepo;
        public QAController(IQARepo iQARepo)
        {
            this._iQARepo = iQARepo;
        }

        public async Task<List<QAViewModel>> Get()
        {
            //Mapping
            IList<string> list = new List<string> { "id" };
            var para = APIProvider.APIDefaultParameter(list, 0);

            var source = await _iQARepo.Query(para);
            List<QAViewModel> dest = Mapper.Map<List<QAViewModel>>(source);

            return dest;
        }


        public async Task<List<QAViewModel>> Get(int id)
        {
            //Mapping
            IList<string> list = new List<string> { "id" };
            var para = APIProvider.APIDefaultParameter(list, id);

            var source = await _iQARepo.Query(para);
            List<QAViewModel> dest = Mapper.Map<List<QAViewModel>>(source);

            return dest;
        }

        [HttpPost]
        public async Task<bool> Transaction(QAViewModel model, char action)
        {
            var obj = Mapper.Map<Domain.Models.CORE.QA>(model);
            return await _iQARepo.Transaction(obj, action);
        }
    }
}
