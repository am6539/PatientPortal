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
    public class FeatureImpl : IFeature
    {
        private readonly IAdapterPattern _adapterPattern;

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="adapterPattern"></param>
        public FeatureImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }
        public async Task<List<Feature>> Query(Dictionary<string, object> param)
        {
            try
            {
                var data = await _adapterPattern.ExecuteQuery<Feature>(param, "usp_spa_Feature", DataConfiguration.instanceCMS);

                return data.ToList();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }
        public async Task<Feature> SingleQuery(Dictionary<string, object> param)
        {
            try
            {
                return await _adapterPattern.SingleExecuteQuery<Feature>(param, "usp_spa_Feature", DataConfiguration.instanceCMS);

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }
    }
}
