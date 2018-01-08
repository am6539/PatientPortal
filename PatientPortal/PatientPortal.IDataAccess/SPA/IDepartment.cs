using PatientPortal.Domain.Models.SPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.Repo.SPA
{
    public interface IDepartment
    {
        Task<List<Department>> Query(Dictionary<string, dynamic> para);
        Task<Department> SingleQuery(Dictionary<string, dynamic> para);
    }
}
