using PatientPortal.DataAccess.Repo.CMS;
using PatientPortal.Domain.Models.CMS;
using PatientPortal.Domain.Models.CMS.Report;
using PatientPortal.IRepository.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Repositoty.CMS
{
    public class PostRepoImpl: IPostRepo
    {
        /// <summary>
        /// Declare variables
        /// </summary>
        IPost _post;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="post"></param>
        public PostRepoImpl(IPost post)
        {
            this._post = post;
        }

        public async Task<Post> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _post.SingleQuery(para);
        }

        public async Task<IEnumerable<AccessPost>> QueryAccess(Dictionary<string, dynamic> para)
        {
            return await _post.QueryAccess(para);
        }

        public async Task<IEnumerable<PostList>> Query(Dictionary<string, dynamic> para)
        {
            return await _post.Query(para);
        }

        public async Task<IEnumerable<DashboardCounter>> Counter(Dictionary<string, dynamic> para)
        {
            return await _post.Counter(para);
        }
        public async Task<int> Transaction(PostEdit data, char action)
        {
            return await _post.Transaction(data, action);
        }
        public async Task<bool> Transaction(PostStateHistory data, char action)
        {
            return await _post.Transaction(data, action);
        }

        public async Task<PostTran> SingleQueryPostTran(Dictionary<string, dynamic> para)
        {
            return await _post.SingleQueryPostTran(para);
        }

        public async Task<bool> Transaction(PostTran data, char action)
        {
            return await _post.Transaction(data, action);
        }
    }
}
