using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.DataAccess.Repo.CORE;
using PatientPortal.Domain.Models.CORE;
using PatientPortal.IRepository.CORE;

namespace PatientPortal.Repositoty.CORE
{
    public class SettingRepoImpl : ISettingRepo
    {
        private ISetting _setting;

        public SettingRepoImpl(ISetting setting)
        {
            this._setting = setting;
        }

        public async Task<Setting> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _setting.SingleQuery(para);
        }
        public async Task<bool> Transaction(Setting data, char action)
        {
            return await _setting.Transaction(data, action);
        }
    }
}
