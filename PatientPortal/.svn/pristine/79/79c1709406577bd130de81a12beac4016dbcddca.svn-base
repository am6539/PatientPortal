using PatientPortal.Domain.Models.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.IRepository.CMS
{
    public interface IWorkflowStateRepo
    {
        Task<WorkflowState> SingleQuery(Dictionary<string, dynamic> para);
        Task<IEnumerable<WorkflowState>> Query(Dictionary<string, dynamic> para);
        Task<bool> Transaction(WorkflowStateEdit data, char action);
        Task<bool> CheckExist(Dictionary<string, dynamic> para);
        Task<bool> CheckIsUsed(Dictionary<string, dynamic> para);

    }
}
