using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.DataAccess.Repo.CORE;
using PatientPortal.Domain.Models.CORE;
using PatientPortal.IRepository.CORE;

namespace PatientPortal.Repositoty.CORE
{
    public class ArticleRepoImpl : IArticleRepo
    {
        private IArticle _articleDA;

        public ArticleRepoImpl(IArticle articleDA)
        {
            this._articleDA = articleDA;
        }

        public async Task<IEnumerable<Article>> Query(Dictionary<string, dynamic> para)
        {
            return await _articleDA.Query(para);
        }

        public async Task<Article> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _articleDA.SingleQuery(para);
        }

        public async Task<int> Transaction(ArticleEdit data, char action)
        {
            return await _articleDA.Transaction(data, action);

        }
    }
}
