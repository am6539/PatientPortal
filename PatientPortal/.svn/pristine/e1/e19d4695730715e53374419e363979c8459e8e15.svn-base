using PatientPortal.DataAccess.Repo.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Core.Models.CMS;
using System.Transactions;
using PatientPortal.DataAccess.Dapper;
using Dapper;
using PatientPortal.Core.Utilities;

namespace PatientPortal.DataAccess.CMS
{
    public class PostStateHistoryImpl : IPostStateHistory
    {
        public List<PostStateHistory> GetAll()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    DapperConfiguration.OpenConnection(1);

                    var data = DapperConfiguration.db.Query<PostStateHistory>("usp_PostStateHistory", commandType: System.Data.CommandType.StoredProcedure).ToList();

                    DapperConfiguration.CloseConnection();

                    scope.Complete();
                    return data;

                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("Execute Category get data: " + ex.Message);
                    return null;
                }
            }
        }
    }
}
