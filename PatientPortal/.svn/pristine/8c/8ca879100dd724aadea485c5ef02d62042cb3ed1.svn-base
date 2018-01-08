using Dapper;
using PatientPortal.DataAccess.Dapper;
using PatientPortal.Domain.Models.SPA;
using PatientPortal.Domain.Utilities;
using PatientPortal.DataAccess.Repo.SPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using System.Data;
using PatientPortal.Domain.LogManager;
using PatientPortal.DataAccess.Repo.Wrapper;

namespace PatientPortal.DataAccess.SPA
{
    public class PostImpl: IPost
    {
        private readonly IAdapterPattern _adapterPattern;

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="adapterPattern"></param>
        public PostImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }

        public async Task<IEnumerable<PostList>> Query(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.ExecuteQuery<PostList>(para, "usp_spa_Post");
        }

        //public async Task<List<PostList>> GetAll(string languageCode, int categoryId, string numTop, byte priority)
        //{
        //    try
        //    {
        //        //DapperConfiguration.OpenConnection(1);
        //        using (IDbConnection dapper = DapperConfiguration.Open(1))
        //        {
        //            var data = await dapper.QueryAsync<PostList>("usp_spa_Post",
        //                new { languageCode = languageCode, categoryId = categoryId, numTop = numTop, priority = priority },
        //                commandType: System.Data.CommandType.StoredProcedure);

        //            dapper.Close();
        //            return data.ToList();
        //        }

        //        // DapperConfiguration.CloseConnection();


        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError(ex);
        //        return null;
        //    }
        //}

        public async Task<Tuple<IEnumerable<PostList>, int>> QueryPaging(Dictionary<string, dynamic> para)
        {
            Tuple<IEnumerable<PostList>, int> data = await _adapterPattern.ExecuteQueryOut<PostList>(para, "usp_spa_Post_Paging", "totalItem", 1);
            return data;
        }

        public async Task<Post> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<Post>(para, "usp_spa_Post_ById");
        }
    }
}
