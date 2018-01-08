using PatientPortal.Domain.Models.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.Repo.CORE
{
    public interface IArticle
    {
        Task<List<Article>> Query(Dictionary<string, object> param);
        Task<Article> SingleQuery(Dictionary<string, object> param);

        Task<int> Transaction(ArticleEdit data, char action);
    }
}
