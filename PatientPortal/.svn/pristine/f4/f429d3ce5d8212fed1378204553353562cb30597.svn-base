using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.IRepository.CORE;
using PatientPortal.Domain.Models.CORE;
using PatientPortal.DataAccess.Repo.CORE;

namespace PatientPortal.Repositoty.CORE
{
    public class DepartmentRepoImpl : IDepartmentRepo
    {
        IDepartment _department;
        public DepartmentRepoImpl(IDepartment department)
        {
            this._department = department;
        }

        public async Task<Department> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _department.SingleQuery(para);
        }

        public async Task<IEnumerable<Department>> Query(Dictionary<string, dynamic> para)
        {
            return await _department.Query(para);
        }

        public async Task<bool> Transaction(Department data, char action)
        {
            return await _department.Transaction(data, action);
        }

        public async Task<bool> CheckExist(Dictionary<string, dynamic> para)
        {
            return await _department.CheckExist(para);
        }
    }
}
