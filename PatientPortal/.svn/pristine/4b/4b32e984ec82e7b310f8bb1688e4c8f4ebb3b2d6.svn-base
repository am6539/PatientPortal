using System;
using System.Collections.Generic;
using System.Linq;
using PatientPortal.Domain.Models.CMS;
using PatientPortal.Domain.Utilities;
using System.Transactions;
using PatientPortal.DataAccess.Dapper;
using Dapper;
using PatientPortal.DataAccess.Repo.CMS;
using PatientPortal.DataAccess.Repo.Wrapper;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.CMS
{
    public class CategoryImpl: ICategory
    {
        private readonly IAdapterPattern _adapterPattern;

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="adapterPattern"></param>
        public CategoryImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }

        /// <summary>
        /// Get by condition
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<Category> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<Category>(para, "usp_Category");
        }

        /// <summary>
        /// Get all 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Category>> Query(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.ExecuteQuery<Category>(para, "usp_Category");
        }

        /// <summary>
        /// Transaction
        /// </summary>
        /// <param name="data"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task<bool> Transaction(Category data, char action)
        {
            return await _adapterPattern.SingleTransaction<Category, bool>(data, "usp_Category_Transaction", action);
        }

        /// <summary>
        /// Check exist item
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<bool> CheckExist(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<bool>(para, "usp_Category_CheckExistName");
        }

        /// <summary>
        /// Check is used
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<bool> CheckIsUsed(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<bool>(para, "usp_Category_CheckIsUsed");
        }
    }
}
