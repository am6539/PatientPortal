using PatientPortal.Domain.Models.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.Repo.CORE
{
    public interface IDepartmentServices
    {
        Task<DepartmentServices> SingleQuery(Dictionary<string, dynamic> para);
        Task<IEnumerable<DepartmentServices>> Query(Dictionary<string, dynamic> para);
        Task<bool> Transaction(DepartmentServices data, char action);
        Task<bool> CheckExist(Dictionary<string, dynamic> para);
    }
}
