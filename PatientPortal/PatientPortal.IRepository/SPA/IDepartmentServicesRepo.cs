using PatientPortal.Domain.Models.SPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.IRepository.SPA
{
    public interface IDepartmentServicesRepo
    {
        Task<IEnumerable<DepartmentServices>> Query(Dictionary<string, dynamic> para);
    }
}
