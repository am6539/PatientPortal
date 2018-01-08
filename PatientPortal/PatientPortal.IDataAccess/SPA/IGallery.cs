using PatientPortal.Domain.Models.SPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.Repo.SPA
{
    public interface IGallery
    {
        Task<IEnumerable<Gallery>> Query(Dictionary<string, dynamic> para);
        Task<Gallery> Get(Dictionary<string, dynamic> para);
    }
}
