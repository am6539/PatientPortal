using PatientPortal.Domain.Models.SPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.IRepository.SPA
{
    public interface IDepartmentRepo
    {
        Task<List<Department>> Query(Dictionary<string, dynamic> para);
        Task<Department> SingleQuery(Dictionary<string, dynamic> para);
    }
}
