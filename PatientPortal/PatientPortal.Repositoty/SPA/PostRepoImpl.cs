using PatientPortal.DataAccess.Repo.SPA;
using PatientPortal.Domain.Models.SPA;
using PatientPortal.IRepository.SPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Repositoty.SPA
{
    public class PostRepoImpl : IPostRepo
    {
        private IPost _iPost;

        public PostRepoImpl(IPost iPost)
        {
            this._iPost = iPost;
        }

        public async Task<IEnumerable<PostList>> Query(Dictionary<string, dynamic> para)
        {
            return await _iPost.Query(para);
        }

        //public Post Get(int Id)
        //{
        //    try
        //    {
        //        var result = _iPost.Get(Id);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        //public Task<List<PostList>> GetAll(string languageCode, int categoryId, string numTop, byte priority)
        //{
        //    try
        //    {
        //        var results = _iPost.GetAll(languageCode, categoryId, numTop, priority);
        //        return results;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public async Task<Tuple<IEnumerable<PostList>, int>> QueryPaging(Dictionary<string, dynamic> para)
        {
            return await _iPost.QueryPaging(para);
        }

        public async Task<Post> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _iPost.SingleQuery(para);
        }
    }
}
