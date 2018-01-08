using PatientPortal.IRepository.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CORE;
using PatientPortal.DataAccess.Repo.CORE;

namespace PatientPortal.Repositoty.CORE
{
    public class DashboardRepoImpl : IDashboardRepo
    {
        IDashboard _iDashboard;
        public DashboardRepoImpl(IDashboard iDashboard)
        {
            this._iDashboard = iDashboard;
        }
        public async Task<IEnumerable<int>> Internal_Counter()
        {
            return await _iDashboard.Internal_Counter();
        }
    }
}
