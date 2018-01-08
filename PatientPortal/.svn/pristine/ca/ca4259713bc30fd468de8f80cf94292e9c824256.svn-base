using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CORE;

namespace PatientPortal.IRepository.CORE
{
    public interface IDepartmentServicesRepo
    {
        Task<DepartmentServices> SingleQuery(Dictionary<string, dynamic> para);
        Task<IEnumerable<DepartmentServices>> Query(Dictionary<string, dynamic> para);
        Task<bool> Transaction(DepartmentServices data, char action);
        Task<bool> CheckExist(Dictionary<string, dynamic> para);
    }
}
