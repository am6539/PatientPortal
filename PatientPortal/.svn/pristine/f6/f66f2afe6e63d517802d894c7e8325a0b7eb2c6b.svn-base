using PatientPortal.Domain.Models.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.IRepository.CMS
{
    public interface ILanguageRepo
    {
        Task<Language> SingleQuery(Dictionary<string, dynamic> para);
        Task<IEnumerable<Language>> Query(Dictionary<string, dynamic> para);
        Task<bool> Transaction(Language data, char action);
        Task<bool> CheckExist(Dictionary<string, dynamic> para);
        Task<bool> CheckIsUsed(Dictionary<string, dynamic> para);
    }
}
