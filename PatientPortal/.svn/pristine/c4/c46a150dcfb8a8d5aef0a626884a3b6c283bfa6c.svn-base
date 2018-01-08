using PatientPortal.Domain.Models.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.Repo.CMS
{
    public interface IWorkflowNavigation
    {
        Task<WorkflowNavigation> SingleQuery(Dictionary<string, dynamic> para);
        Task<IEnumerable<WorkflowNavigation>> Query(Dictionary<string, dynamic> para);
        Task<bool> Transaction(WorkflowNavigationEdit data, char action);
    }
}
