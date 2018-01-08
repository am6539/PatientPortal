using PatientPortal.API.SPA.ViewModels;
using PatientPortal.Domain.Caching.Redis.StackExchange;
using PatientPortal.IRepository.SPA;
using PatientPortal.Utility.Files;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;

namespace PatientPortal.API.SPA.Controllers
{
    public class AdvertiseController : ApiController
    {
        private readonly IAdvertiseRepo _iAdvertiseRepo;
        private RedisCacheService redisCache = new RedisCacheService();

        public AdvertiseController(IAdvertiseRepo iAdvertiseRepo)
        {
            this._iAdvertiseRepo = iAdvertiseRepo;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var results = redisCache.GetList<AdvertiseViewModel>();

                if(results == null)
                {
                    var data = _iAdvertiseRepo.GetAll();
                    if(data != null && data.Count > 0)
                    {
                        results = data.Select(s => new AdvertiseViewModel() {

                            Id = s.Id,
                            Name = s.Name,
                            Resouce = LayoutGuide.SPA_ResourcePath(Provider.Common.APIEnums.Application.CMS, s.Resouce),
                            Handler = s.Handler,
                            Type = s.Type,
                            StartDate = s.StartDate,
                            EndDate = s.EndDate,
                            Image = (s.Type > 0  ? LayoutGuide.SPA_ResourcePath(Provider.Common.APIEnums.Application.CMS, s.Resouce.Split('.')[0]) : s.Resouce)

                    }).AsEnumerable();
                    }

                    redisCache.AddList<AdvertiseViewModel>(results);

                    //foreach (var item in data)
                    //{
                    //    var advertise = new AdvertiseViewModel();
                    //    advertise.Id = item.Id;
                    //    advertise.Name = item.Name;
                    //    advertise.Resouce = LayoutGuide.SPA_ResourcePath(Provider.Common.APIEnums.Application.CMS, item.Resouce);
                    //    advertise.Handler = item.Handler;
                    //    advertise.Type = item.Type;
                    //    advertise.StartDate = item.StartDate;
                    //    advertise.EndDate = item.EndDate;
                    //    if (item.Type > 0)
                    //    {
                    //        advertise.Image = LayoutGuide.SPA_ResourcePath(Provider.Common.APIEnums.Application.CMS, item.Resouce.Split('.')[0]);
                    //    }
                    //    else
                    //    {
                    //        advertise.Image = advertise.Resouce;
                    //    }
                    //    results.Add(advertise);
                    //}
                }
                
                return Request.CreateResponse(HttpStatusCode.OK, results);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
