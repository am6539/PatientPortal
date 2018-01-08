using PatientPortal.Domain.Models.SPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.IRepository.SPA
{
    public interface IPostRepo
    {
        //Task<List<PostList>> GetAll(string languageCode, int categoryId, string numTop, byte priority);
        //Post Get(int Id);
        Task<IEnumerable<PostList>> Query(Dictionary<string, dynamic> para);
        Task<Tuple<IEnumerable<PostList>, int>> QueryPaging(Dictionary<string, dynamic> para);
        Task<Post> SingleQuery(Dictionary<string, dynamic> para);
    }
}
