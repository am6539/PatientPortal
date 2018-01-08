using PatientPortal.DataAccess.Repo.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CORE;
using System.Transactions;
using PatientPortal.DataAccess.Dapper;
using Dapper;
using PatientPortal.Domain.Utilities;
using PatientPortal.DataAccess.Repo.Wrapper;
using PatientPortal.Domain.Common;
using PatientPortal.Domain.LogManager;

namespace PatientPortal.DataAccess.CORE
{
    public class ArticleImpl : IArticle
    {
        private readonly IAdapterPattern _adapterPattern;

        public ArticleImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }

        /// <summary>
        /// Transaction
        /// </summary>
        /// <param name="data"></param>
        /// <param name="action"></param>
        /// <returns>true/false</returns>
        public async Task<int> Transaction(ArticleEdit data, char action)
        {
            try
            {
                var val = await _adapterPattern.SingleTransaction<ArticleEdit, int>(data, "usp_Article_Transaction", action, DataConfiguration.instanceCore);
                return val;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return 0;
            }
        }

        /// <summary>
        /// Query
        /// </summary>
        /// <param name="param"></param>
        /// <returns>List Article</returns>
        public async Task<List<Article>> Query(Dictionary<string, object> param)
        {
            try
            {
                var data = await _adapterPattern.ExecuteQuery<Article>(param, "usp_Article", DataConfiguration.instanceCore);

                return data.ToList();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }

        public async Task<Article> SingleQuery(Dictionary<string, object> param)
        {
            try
            {
                return await _adapterPattern.SingleExecuteQuery<Article>(param, "usp_Article", DataConfiguration.instanceCore);

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }
    }
}
