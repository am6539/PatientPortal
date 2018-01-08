using PatientPortal.DataAccess.Repo.CORE;
using System.Collections.Generic;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CORE;
using PatientPortal.DataAccess.Repo.Wrapper;
using PatientPortal.Domain.Common;

namespace PatientPortal.DataAccess.CORE
{
    public class EmailMarketingImpl : IEmailMarketing
    {
        private readonly IAdapterPattern _adapterPattern;

        public EmailMarketingImpl(IAdapterPattern adapterPattern)
        {
            this._adapterPattern = adapterPattern;
        }

        public async Task<IEnumerable<EmailMarketing>> Query(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.ExecuteQuery<EmailMarketing>(para, "usp_EmailMarketing", DataConfiguration.instanceCore);
        }

        public async Task<EmailMarketing> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _adapterPattern.SingleExecuteQuery<EmailMarketing>(para, "usp_EmailMarketing", DataConfiguration.instanceCore);
        }
        
        public async Task<int> Transaction(EmailMarketing data, char action)
        {
            return await _adapterPattern.SingleTransaction<EmailMarketing, int>(data, "usp_EmailMarketing_Transaction", action, DataConfiguration.instanceCore);
        }
    }
}
