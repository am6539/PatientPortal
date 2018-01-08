using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.IRepository.CMS;
using PatientPortal.Domain.Models.CMS;
using PatientPortal.DataAccess.Repo.CMS;

namespace PatientPortal.Repositoty.CMS
{
    public class ConfigurationRepoImpl : IConfigurationRepo
    {
        IConfiguration _config;
        public ConfigurationRepoImpl(IConfiguration config)
        {
            this._config = config;
        }


        public async Task<CMSConfiguration> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _config.SingleQuery(para);
        }
        public async Task<bool> Transaction(CMSConfiguration data, char action)
        {
            return await _config.Transaction(data, action);
        }
    }
}
