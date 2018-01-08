using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.CMS.Models
{
    public class WorkflowsModel
    {
        public WorkflowViewModel WorkflowViewModel { get; set; }
        public List<WorkflowViewModel> lstWorkflowViewModel { get; set; }
    }
}