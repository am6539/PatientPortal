using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CMS;
using PatientPortal.Domain.Utilities;
using PatientPortal.DataAccess.Dapper;
using Dapper;
using System.Transactions;
using PatientPortal.DataAccess.Repo.CMS;
using PatientPortal.DataAccess.Repo.Wrapper;

namespace PatientPortal.DataAccess.CMS
{
    public class LanguageImpl : ILanguage
    {
        private readonly IAdapterPattern _adapterPattern;

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="adapterPattern"></param>
        public LanguageImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }

        /// <summary>
        /// Get by condition
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<Language> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<Language>(para, "usp_Language");
        }

        /// <summary>
        /// Get all 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Language>> Query(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.ExecuteQuery<Language>(para, "usp_Language");
        }

        /// <summary>
        /// Transaction
        /// </summary>
        /// <param name="data"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task<bool> Transaction(Language data, char action)
        {
            return await _adapterPattern.SingleTransaction<Language, bool>(data, "usp_Language_Transaction", action);
        }

        /// <summary>
        /// Check exist item
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<bool> CheckExist(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<bool>(para, "usp_Language_CheckExistCode");
        }

        /// <summary>
        /// Check is used
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<bool> CheckIsUsed(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<bool>(para, "usp_Language_CheckIsUsed");
        }
    }
}
