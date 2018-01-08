using PatientPortal.Domain.Models.CORE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.Repo.CORE
{
    public interface ISetting
    {
        Task<Setting> SingleQuery(Dictionary<string, dynamic> para);
        Task<bool> Transaction(Setting data, char action);
    }
}
