using PatientPortal.DataAccess.Repo.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CORE;
using PatientPortal.DataAccess.Repo.Wrapper;
using PatientPortal.Domain.Common;

namespace PatientPortal.DataAccess.CORE
{
    public class DashboardImpl : IDashboard
    {
        private readonly IAdapterPattern _adapterPattern;

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="adapterPattern"></param>
        public DashboardImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }
       
        public Task<IEnumerable<int>> Internal_Counter()
        {
            return _adapterPattern.ExecuteQuery<int>(null, "usp_Internal_Dashboard", DataConfiguration.instanceCore);
        }
    }
}
