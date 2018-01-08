using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.IRepository.CMS;
using PatientPortal.Domain.Models.CMS;
using PatientPortal.DataAccess.Repo.CMS;

namespace PatientPortal.Repositoty.CMS
{
    public class GalleryRepoImpl : IGalleryRepo
    {
        IGallery _gallery;
        public GalleryRepoImpl(IGallery gallery)
        {
            this._gallery = gallery;
        }

        public async Task<Gallery> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _gallery.SingleQuery(para);
        }

        public async Task<IEnumerable<Gallery>> Query(Dictionary<string, dynamic> para)
        {
            return await _gallery.Query(para);
        }

        public async Task<bool> Transaction(Gallery data, char action)
        {
            return await _gallery.Transaction(data, action);
        }

        public async Task<bool> CheckExist(Dictionary<string, dynamic> para)
        {
            return await _gallery.CheckExist(para);
        }
    }
}
