using PatientPortal.Domain.Models.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.Repo.CORE
{
    public interface IQA
    {
        Task<QA> SingleQuery(Dictionary<string, dynamic> para);
        Task<IEnumerable<QA>> Query(Dictionary<string, dynamic> para);
        Task<bool> Transaction(QA data, char action);
    }
}
