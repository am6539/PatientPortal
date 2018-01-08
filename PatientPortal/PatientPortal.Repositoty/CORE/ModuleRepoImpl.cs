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
    public class ModuleRepoImpl : IModuleRepo
    {
        private IModule _module;

        public ModuleRepoImpl(IModule module)
        {
            this._module = module;
        }
        public async Task<bool> CheckExist(Dictionary<string, dynamic> para)
        {
            return await _module.CheckExist(para);
        }

        public async Task<Module> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _module.SingleQuery(para);
        }

        public async Task<IEnumerable<Module>> Query(Dictionary<string, dynamic> para)
        {
            return await _module.Query(para, "usp_Module");
        }
        public async Task<IEnumerable<Module>> Initial(Dictionary<string, dynamic> para)
        {
            return await _module.Query(para, "usp_Module_Initial");
        }
        public async Task<bool> Transaction(Module data, char action)
        {
            return await _module.Transaction(data, action);
        }

        public async Task<bool> CheckIsUsed(Dictionary<string, dynamic> para)
        {
            return await _module.CheckIsUsed(para);
        }
    }
}
