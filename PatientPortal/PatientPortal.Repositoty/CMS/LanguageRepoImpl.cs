using PatientPortal.IRepository.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CMS;
using PatientPortal.DataAccess.Repo.CMS;

namespace PatientPortal.Repositoty.CMS
{
    public class LanguageRepoImpl : ILanguageRepo
    {
        /// <summary>
        /// declare variables
        /// </summary>
        ILanguage _language;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="language"></param>
        public LanguageRepoImpl(ILanguage language)
        {
            this._language = language;
        }

        public async Task<Language> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _language.SingleQuery(para);
        }
        public async Task<IEnumerable<Language>> Query(Dictionary<string, dynamic> para)
        {
            return await _language.Query(para);
        }
        public async Task<bool> Transaction(Language data, char action)
        {
            return await _language.Transaction(data, action);
        }
        public async Task<bool> CheckExist(Dictionary<string, dynamic> para)
        {
            return await _language.CheckExist(para);
        }
        public async Task<bool> CheckIsUsed(Dictionary<string, dynamic> para)
        {
            return await _language.CheckIsUsed(para);
        }
    }
}
