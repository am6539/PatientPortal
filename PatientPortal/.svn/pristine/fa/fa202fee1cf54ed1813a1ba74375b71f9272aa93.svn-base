using PatientPortal.DataAccess.Repo.SPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.SPA;
using PatientPortal.DataAccess.Repo.Wrapper;
using PatientPortal.Domain.LogManager;
using PatientPortal.Domain.Common;

namespace PatientPortal.DataAccess.SPA
{
    public class DepartmentServicesImpl : IDepartmentServices
    {
        private readonly IAdapterPattern _adapterPattern;

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="adapterPattern"></param>
        public DepartmentServicesImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }
        public async Task<IEnumerable<DepartmentServices>> Query(Dictionary<string, dynamic> para)
        {
            try
            {
                var data = await _adapterPattern.ExecuteQuery<DepartmentServices>(para, "usp_spa_DepartmentServices", DataConfiguration.instanceCore);

                return data.ToList();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }
    }
}
