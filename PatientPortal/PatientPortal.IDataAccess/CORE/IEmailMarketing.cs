using PatientPortal.Domain.Models.CORE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.Repo.CORE
{
    public interface IEmailMarketing
    {
        Task<IEnumerable<EmailMarketing>> Query(Dictionary<string, dynamic> para);
        Task<EmailMarketing> SingleQuery(Dictionary<string, dynamic> para);
        Task<int> Transaction(EmailMarketing data, char action);
    }
}
