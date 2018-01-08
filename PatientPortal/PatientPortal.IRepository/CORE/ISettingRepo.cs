using System.Collections.Generic;
using System.Threading.Tasks;
using PatientPortal.Domain.Models.CORE;

namespace PatientPortal.IRepository.CORE
{
    public interface ISettingRepo
    {
        Task<Setting> SingleQuery(Dictionary<string, dynamic> para);
        Task<bool> Transaction(Setting data, char action);
    }
}
