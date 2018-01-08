using PatientPortal.DataAccess.Repo.SPA;
using PatientPortal.Domain.Models.SPA;
using PatientPortal.IRepository.SPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Repositoty.SPA
{
    public class DepartmentRepoImpl: IDepartmentRepo
    {
        readonly IDepartment _iDepartment;

        public DepartmentRepoImpl(IDepartment iDepartment)
        {
            this._iDepartment = iDepartment;
        }

        public async Task<List<Department>> Query(Dictionary<string, dynamic> para)
        {
            return await _iDepartment.Query(para);
        }

        public async Task<Department> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _iDepartment.SingleQuery(para);
        }
    }
}
