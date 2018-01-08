using PatientPortal.Domain.Models.SPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.IRepository.SPA
{
    public interface IGalleryRepo
    {
        Task<IEnumerable<Gallery>> Query(Dictionary<string, dynamic> para);
        Task<Gallery> Get(Dictionary<string, dynamic> para);
    }
}
