using System.Collections.Generic;
using System.Threading.Tasks;
using PatientPortal.DataAccess.Repo.CORE;
using PatientPortal.Domain.Models.CORE;
using PatientPortal.IRepository.CORE;

namespace PatientPortal.Repositoty.CORE
{
    public class EmailMarketingRepoImpl : IEmailMarketingRepo
    {
        private readonly IEmailMarketing _emailMarketing;

        public EmailMarketingRepoImpl(IEmailMarketing emailMarketing)
        {
            this._emailMarketing = emailMarketing;
        }

        public async Task<EmailMarketing> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _emailMarketing.SingleQuery(para);
        }

        public async Task<IEnumerable<EmailMarketing>> Query(Dictionary<string, dynamic> para)
        {
            return await _emailMarketing.Query(para);
        }

        public async Task<int> Transaction(EmailMarketing data, char action)
        {
            return await _emailMarketing.Transaction(data, action);
        }
    }
}
