using System.Collections.Generic;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CORE;

namespace PatientPortal.IRepository.CORE
{
    public interface IEmailMarketingRepo
    {
        Task<IEnumerable<EmailMarketing>> Query(Dictionary<string, dynamic> para);
        Task<EmailMarketing> SingleQuery(Dictionary<string, dynamic> para);
        Task<int> Transaction(EmailMarketing data, char action);
    }
}
