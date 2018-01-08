using AutoMapper;
using PatientPortal.API.SPA.ViewModels;
using PatientPortal.Domain.Caching.Redis.StackExchange;
using PatientPortal.IRepository.SPA;
using PatientPortal.Provider.Models;
using PatientPortal.Utility.Files;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;
using System.Linq;

namespace PatientPortal.API.SPA.Controllers
{
    public class GalleryController : ApiController
    {
        private readonly IGalleryRepo _iGalleryRepo;
        private RedisCacheService redisCache = new RedisCacheService();

        public GalleryController(IGalleryRepo iGalleryRepo)
        {
            this._iGalleryRepo = iGalleryRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<GalleryViewModel>> Query(byte departmentId = 0)
        {
            try
            {
                var results = await redisCache.GetListAsync<GalleryViewModel>("DepartmentId");
                if(results == null)
                {
                    List<string> list = new List<string> { "Id", "DepartmentId" };
                    Dictionary<string, dynamic> para = APIProvider.APIDefaultParameter(list, null, departmentId);
                    var source = await _iGalleryRepo.Query(para);
                    results = source.Select(s => new GalleryViewModel() {
                        Id = s.Id,
                        Title = s.Title,
                        Description = s.Description,
                        Highlight = s.Highlight,
                        Img = s.Img != null ? LayoutGuide.SPA_ResourcePath(Provider.Common.APIEnums.Application.CMS, s.Img) : null,
                        YoutubeURL = s.YoutubeURL,
                        Date = s.Date,
                        DepartmentId = s.DepartmentId,
                        IsMultiple = s.IsMultiple
                    }).AsEnumerable();

                    //
                    await redisCache.AddListAsync<GalleryViewModel>(results, "DepartmentId", "Id");
                    await redisCache.AddListAsync<GalleryViewModel>(results);
                }
                
                //List<GalleryViewModel> dest = Mapper.Map<List<GalleryViewModel>>(source);
                return results;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        public async Task<GalleryViewModel> Get(string id)
        {
            var result = await redisCache.GetAsync<GalleryViewModel>("DepartmentId");
            if(result == null)
            {
                IList<string> list = new List<string> { "Id", "DepartmentId" };
                var para = APIProvider.APIDefaultParameter(list, id, 0);
                var source = await _iGalleryRepo.Get(para);
                result = new GalleryViewModel();
                if (source != null)
                {
                    result.Id = source.Id;
                    result.Title = source.Title;
                    result.Description = source.Description;
                    result.Highlight = source.Highlight;
                    result.Img = source.Img != null ? LayoutGuide.SPA_ResourcePath(Provider.Common.APIEnums.Application.CMS, result.Img) : null;
                    result.YoutubeURL = source.YoutubeURL;
                    result.Date = source.Date;
                    result.DepartmentId = source.DepartmentId;
                    result.IsMultiple = source.IsMultiple;
                }
            }
            
            return result;
        }
    }
}