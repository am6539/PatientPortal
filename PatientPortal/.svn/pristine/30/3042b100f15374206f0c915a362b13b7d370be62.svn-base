using Dapper;
using PatientPortal.DataAccess.Dapper;
using PatientPortal.DataAccess.Repo.SPA;
using PatientPortal.Domain.Models.SPA;
using PatientPortal.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using PatientPortal.Domain.LogManager;
using System.Data;
using PatientPortal.DataAccess.Repo.Wrapper;
using PatientPortal.Domain.Common;

namespace PatientPortal.DataAccess.SPA
{
    public class DepartmentImpl: IDepartment
    {
        private readonly IAdapterPattern _adapterPattern;

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="adapterPattern"></param>
        public DepartmentImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }
        public async Task<List<Department>> Query(Dictionary<string, object> param)
        {
            try
            {
                var data = await _adapterPattern.ExecuteQuery<Department>(param, "usp_spa_Department", DataConfiguration.instanceCore);

                return data.ToList();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }

        public async Task<Department> SingleQuery(Dictionary<string, object> param)
        {
            try
            {
                return await _adapterPattern.SingleExecuteQuery<Department>(param, "usp_spa_Department", DataConfiguration.instanceCore);

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }
    }
}
