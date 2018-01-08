using PatientPortal.DataAccess.Repo.CMS;
using System.Collections.Generic;
using PatientPortal.Domain.Models.CMS;
using PatientPortal.DataAccess.Repo.Wrapper;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CMS.Report;
using PatientPortal.Domain.Caching.Redis.StackExchange;

namespace PatientPortal.DataAccess.CMS
{
    public class PostImpl : IPost
    {
        private readonly IAdapterPattern _adapterPattern;
        private RedisCacheService _redis;

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="adapterPattern"></param>
        public PostImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
            this._redis = new RedisCacheService();
        }

        /// <summary>
        /// Get by condition
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<Post> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<Post>(para, "usp_Post");
        }

        /// <summary>
        /// Get all 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PostList>> Query(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.ExecuteQuery<PostList>(para, "usp_Post");
        }

        public async Task<IEnumerable<AccessPost>> QueryAccess(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.ExecuteQuery<AccessPost>(para, "usp_PostAccess");
        }

        /// <summary>
        /// Get all 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DashboardCounter>> Counter(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.ExecuteQuery<DashboardCounter>(para, "usp_Dashboard_Counter");
        }

        /// <summary>
        /// Transaction
        /// </summary>
        /// <param name="data"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task<int> Transaction(PostEdit data, char action)
        {
            return await _adapterPattern.SingleTransaction<PostEdit, int>(data, "usp_Post_Transaction", action);
        }


        /// <summary>
        /// Transaction
        /// </summary>
        /// <param name="data"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task<bool> Transaction(PostStateHistory data, char action)
        {
            return await _adapterPattern.SingleTransaction<PostStateHistory, bool>(data, "usp_Post_WorkflowState_Transaction", action);
        }

        #region POST TRANS
        public async Task<PostTran> SingleQueryPostTran(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<PostTran>(para, "usp_PostTrans");
        }
        public async Task<bool> Transaction(PostTran data, char action)
        {
            return await _adapterPattern.SingleTransaction<PostTran, bool>(data, "usp_PostTrans_Transaction", action);
        }
        #endregion

    }
}
