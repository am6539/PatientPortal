using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CORE;

namespace PatientPortal.IRepository.CORE
{
    public interface IDepartmentRepo
    {
        Task<Department> SingleQuery(Dictionary<string, dynamic> para);
        Task<IEnumerable<Department>> Query(Dictionary<string, dynamic> para);
        Task<bool> Transaction(Department data, char action);
        Task<bool> CheckExist(Dictionary<string, dynamic> para);
    }
}
