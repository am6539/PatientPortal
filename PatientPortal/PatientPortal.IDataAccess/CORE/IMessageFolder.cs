using PatientPortal.Domain.Models.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.Repo.CORE
{
    public interface IMessageFolder
    {
        Task<List<MessageFolder>> Query(Dictionary<string, object> param);
        Task<int> Transaction(MessageFolder data, char action);
    }
}
