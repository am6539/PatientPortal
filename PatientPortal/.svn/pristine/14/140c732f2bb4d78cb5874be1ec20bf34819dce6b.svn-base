using AutoMapper;
using PatientPortal.API.SPA.ViewModels;
using PatientPortal.Domain.Caching.Redis.StackExchange;
using PatientPortal.IRepository.SPA;
using PatientPortal.Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PatientPortal.API.SPA.Controllers
{
    public class DepartmentServiceController : ApiController
    {
        readonly IDepartmentServicesRepo _departmentService;
        readonly IDepartmentRepo _department;
        private RedisCacheService redisCache = new RedisCacheService();

        public DepartmentServiceController(IDepartmentServicesRepo departmentService, IDepartmentRepo department)
        {
            this._departmentService = departmentService;
            _department = department;
        }

        public async Task<IEnumerable<DepartmentServiceViewModel>> GetServices(short departmentId)
        {
            var results = await redisCache.GetListAsync<DepartmentServiceViewModel>("DepartmentId");
            if(results == null)
            {
                IList<string> list = new List<string> { "Id", "DepartmentId" };
                var paraService = APIProvider.APIDefaultParameter(list, 0, departmentId);

                var source = await _departmentService.Query(paraService);
               results = Mapper.Map<List<DepartmentServiceViewModel>>(source);

                //
                await redisCache.AddListAsync<DepartmentServiceViewModel>(results, "DepartmentId", "Id");
            }
            
            return results;
        }
    }
}
