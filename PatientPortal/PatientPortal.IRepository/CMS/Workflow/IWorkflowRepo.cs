using PatientPortal.Domain.Models.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.IRepository.CMS
{
    public interface IWorkflowRepo
    {
        Task<Workflow> SingleQuery(Dictionary<string, dynamic> para);
        Task<IEnumerable<Workflow>> Query(Dictionary<string, dynamic> para);
        Task<bool> Transaction(Workflow data, char action);
        Task<bool> CheckExist(Dictionary<string, dynamic> para);
        Task<bool> CheckIsUsed(Dictionary<string, dynamic> para);
    }
}
