
using System;
using PatientPortal.Domain.Models.SPA;
using PatientPortal.DataAccess.Repo.SPA;
using PatientPortal.IRepository.SPA;

namespace PatientPortal.Repositoty.SPA
{
    public class ConfigurationRepoImpl : IConfigurationRepo
    {
        private IConfiguration _iConfiguration;

        public ConfigurationRepoImpl(IConfiguration iConfiguration)
        {
            this._iConfiguration = iConfiguration;
        }

        public Configuration Get(byte Id)
        {
            return _iConfiguration.GetById(Id);
        }
    }
}
