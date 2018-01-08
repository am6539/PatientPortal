using System.Collections.Generic;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CORE;

namespace PatientPortal.IRepository.CORE
{
    public interface IArticleCommentRepo
    {
        Task<IEnumerable<ArticleComment>> Query(Dictionary<string, dynamic> para);

        Task<ArticleComment> SingleQuery(Dictionary<string, dynamic> para);

        Task<int> Transaction(ArticleCommentEdit data, char action);

    }
}
