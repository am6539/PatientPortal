using PatientPortal.DataAccess.Repo.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Core.Models.CMS;
using PatientPortal.Core.Utilities;
using PatientPortal.DataAccess.Dapper;
using Dapper;
using System.Transactions;

namespace PatientPortal.DataAccess.CMS
{
    public class PostSEOImpl : IPostSEO
    {
        public List<PostSEO> GetAll()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    DapperConfiguration.OpenConnection(1);

                    var data = DapperConfiguration.db.Query<PostSEO>("usp_PostSEO_GetAll", commandType: System.Data.CommandType.StoredProcedure).ToList();

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
