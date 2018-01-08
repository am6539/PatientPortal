using AutoMapper;
using PatientPortal.API.SPA.ViewModels;
using PatientPortal.Domain.Caching.Redis.StackExchange;
using PatientPortal.IRepository.CORE;
using PatientPortal.Provider.Models;
using PatientPortal.Utility.Files;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PatientPortal.API.SPA.Controllers
{
    public class DoctorProfileController : ApiController
    {
        private readonly IDoctorProfileRepo _doctor;
        private RedisCacheService redisCache = new RedisCacheService();

        public DoctorProfileController(IDoctorProfileRepo doctor)
        {
            this._doctor = doctor;
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<DoctorProfileViewModel>> Get()
        {
            var results = await redisCache.GetListAsync<DoctorProfileViewModel>();
            if(results == null)
            {
                List<string> list = new List<string> { "userid" };
                var para = APIProvider.APIDefaultParameter(list, string.Empty);

                var source = await _doctor.Query(para);
                results = source.Select(s => new DoctorProfileViewModel(){
                    UserId = s.UserId,
                    Speciality = s.Speciality,
                    Degrees = s.Degrees,
                    Training = s.Training,
                    Office = s.Office,
                    Workdays = s.Workdays,
                    Name = s.Name,
                    Image = s.Image

                }).AsEnumerable();

                //
                await redisCache.AddListAsync<DoctorProfileViewModel>(results, "UserId");
                //var dest = Mapper.Map<List<DoctorProfileViewModel>>(source);
            }
            return results;
        }

        /// <summary>
        /// Filter by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<DoctorProfileViewModel> Get(string id)
        {
            var result = await redisCache.GetAsync<DoctorProfileViewModel>(id);
            if(result == null)
            {
                List<string> list = new List<string> { "UserId" };
                var para = APIProvider.APIGeneratorParameter(list, id);

                var source = await _doctor.SingleQuery(para);
                result = Mapper.Map<DoctorProfileViewModel>(source);
            }
            return result;
        }
    }
}
