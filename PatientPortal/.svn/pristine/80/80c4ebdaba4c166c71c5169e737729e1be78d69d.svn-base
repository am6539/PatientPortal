using Dapper;
using PatientPortal.DataAccess.Dapper;
using PatientPortal.Domain.Models.SPA;
using PatientPortal.Domain.Utilities;
using PatientPortal.DataAccess.Repo.SPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using PatientPortal.Domain.LogManager;
using PatientPortal.DataAccess.Repo.Wrapper;

namespace PatientPortal.DataAccess.SPA
{
    public class ConfigurationImpl : IConfiguration
    {
        private readonly IAdapterPattern _adapterPattern;
        /// <summary>
        /// Init
        /// </summary>
        /// <param name="adapterPattern"></param>
        public ConfigurationImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }

        public Configuration GetById(byte id)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    DapperConfiguration.OpenConnection(1);

                    var data = DapperConfiguration.db.Query<Configuration>("usp_spa_CMSConfig",
                        new { Id = id },
                        commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();

                    DapperConfiguration.CloseConnection();

                    scope.Complete();
                    return data;

                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    return null;
                }
            }
        }

        public async Task<SEOPage> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<SEOPage>(para, "usp_spa_SEOPage");
        }

    }
}
