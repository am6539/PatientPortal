using AutoMapper;
using PatientPortal.API.SPA.ViewModels;
using PatientPortal.Domain.Caching.Redis.StackExchange;
using PatientPortal.IRepository.SPA;
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
    public class FeatureController : ApiController
    {
        private readonly IFeatureRepo _iFeatureRepo;
        private RedisCacheService redisCache = new RedisCacheService();

        public FeatureController(IFeatureRepo iFeatureRepo)
        {
            this._iFeatureRepo = iFeatureRepo;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                var results = await redisCache.GetListAsync<FeatureViewModel>();

                if (results == null || results.Count() == 0)
                {
                    List<string> list = new List<string> { "Id" };
                    var para = APIProvider.APIDefaultParameter(list, 0);

                    var data = await _iFeatureRepo.Query(para);
                    var listFeatures = Mapper.Map<List<FeatureViewModel>>(data);
                    results = data.Select(s => new FeatureViewModel()
                    {

                        Id = s.Id,
                        Title = s.Title,
                        Image = LayoutGuide.SPA_ResourcePath(Provider.Common.APIEnums.Application.CMS, s.Image),
                        Description = s.Description,
                        Handler = s.Handler,
                        IsUsed = s.IsUsed
                    }).AsEnumerable();

                    //
                    await redisCache.AddListAsync<FeatureViewModel>(results);
                }
                
                return Request.CreateResponse(HttpStatusCode.OK, results);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get(byte id)
        {
            var result = await redisCache.GetAsync<FeatureViewModel>(id);
            if(result == null)
            {
                List<string> list = new List<string> { "Id" };
                var para = APIProvider.APIDefaultParameter(list, id);

                var data = await _iFeatureRepo.SingleQuery(para);
                result = new FeatureViewModel
                {
                    Id = data.Id,
                    Title = data.Title,
                    Image = LayoutGuide.SPA_ResourcePath(Provider.Common.APIEnums.Application.CMS, data.Image),
                    Description = data.Description,
                    Handler = data.Handler,
                    IsUsed = data.IsUsed
                };

                //
                await redisCache.AddAsync<FeatureViewModel>(result);
            }
            

            return Request.CreateResponse(HttpStatusCode.OK, result); 
        }
    }
}
