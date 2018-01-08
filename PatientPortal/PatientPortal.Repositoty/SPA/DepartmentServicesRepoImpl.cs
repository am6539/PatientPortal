
using PatientPortal.DataAccess.Repo.SPA;
using PatientPortal.IRepository.SPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.SPA;

namespace PatientPortal.Repositoty.SPA
{
    public class DepartmentServicesRepoImpl : IDepartmentServicesRepo
    {
        readonly IDepartmentServices _iDepartmentService;

        public DepartmentServicesRepoImpl(IDepartmentServices iDepartmentService)
        {
            this._iDepartmentService = iDepartmentService;
        }

        public async Task<IEnumerable<DepartmentServices>> Query(Dictionary<string, dynamic> para)
        {
            return await _iDepartmentService.Query(para);
        }
    }
}
