using Dapper;
using PatientPortal.DataAccess.Dapper;
using PatientPortal.Domain.Models.SPA;
using PatientPortal.Domain.Utilities;
using PatientPortal.DataAccess.Repo.SPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using PatientPortal.Domain.LogManager;

namespace PatientPortal.DataAccess.SPA
{
    public class AdvertiseImpl : IAdvertise
    {
        public List<Advertise> GetAll()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    DapperConfiguration.OpenConnection(1);

                    var data = DapperConfiguration.db.Query<Advertise>("usp_spa_Advertise",
                        new { Id = GlobalVariables.IsTransParameter },
                        commandType: System.Data.CommandType.StoredProcedure).ToList();

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
    }
}
