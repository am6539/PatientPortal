using PatientPortal.Domain.Models.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.Repo.CORE
{
    public interface IDepartment
    {
        Task<Department> SingleQuery(Dictionary<string, dynamic> para);
        Task<IEnumerable<Department>> Query(Dictionary<string, dynamic> para);
        Task<bool> Transaction(Department data, char action);
        Task<bool> CheckExist(Dictionary<string, dynamic> para);
    }
}
