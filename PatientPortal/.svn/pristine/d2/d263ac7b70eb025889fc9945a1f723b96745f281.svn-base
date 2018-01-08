using PatientPortal.Domain.Models.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.Repo.CMS
{
    public interface IGalleryStore
    {
        Task<GalleryStore> SingleQuery(Dictionary<string, dynamic> para);
        Task<IEnumerable<GalleryStore>> Query(Dictionary<string, dynamic> para);
        Task<bool> Transaction(GalleryStore data, char action);
        Task<bool> CheckExist(Dictionary<string, dynamic> para);
    }
}
