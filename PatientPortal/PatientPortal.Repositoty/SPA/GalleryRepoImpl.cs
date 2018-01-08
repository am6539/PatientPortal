using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PatientPortal.DataAccess.Repo.SPA;
using PatientPortal.Domain.Models.SPA;
using PatientPortal.IRepository.SPA;

namespace PatientPortal.Repositoty.SPA
{
    public class GalleryRepoImpl : IGalleryRepo
    {
        private IGallery _iGallery;

        public GalleryRepoImpl(IGallery iGallery)
        {
            this._iGallery = iGallery;
        }

        public async Task<Gallery> Get(Dictionary<string, dynamic> para)
        {
            return await _iGallery.Get(para);
        }

        public async Task<IEnumerable<Gallery>> Query(Dictionary<string, dynamic> para)
        {
            return await _iGallery.Query(para);
        }
    }
}
