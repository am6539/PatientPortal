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
    public class ArticleCommentRepoImpl : IArticleCommentRepo
    {
        private IArticleComment _articleCommentDA;

        public ArticleCommentRepoImpl(IArticleComment articleCommentDA)
        {
            this._articleCommentDA = articleCommentDA;
        }

        public async Task<IEnumerable<ArticleComment>> Query(Dictionary<string, dynamic> para)
        {
            return await _articleCommentDA.Query(para);
        }

        public async Task<ArticleComment> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _articleCommentDA.SingleQuery(para);

        }

        public async Task<int> Transaction(ArticleCommentEdit data, char action)
        {
            return await _articleCommentDA.Transaction(data, action);
        }
    }
}
