using System.Collections.Generic;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CORE;

namespace PatientPortal.IRepository.CORE
{
    public interface IArticleRepo
    {
        Task<IEnumerable<Article>> Query(Dictionary<string, dynamic> para);

        Task<Article> SingleQuery(Dictionary<string, dynamic> para);

        Task<int> Transaction(ArticleEdit data, char action);

    }
}
