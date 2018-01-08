using PatientPortal.Domain.Models.SPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.Repo.SPA
{
    public interface IPost
    {
        Task<IEnumerable<PostList>> Query(Dictionary<string, dynamic> para);
        Task<Tuple<IEnumerable<PostList>, int>> QueryPaging(Dictionary<string, dynamic> para);
        Task<Post> SingleQuery(Dictionary<string, dynamic> para);
    }
}
