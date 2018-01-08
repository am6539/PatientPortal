using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.DataAccess.EntityFramework;

namespace PatientPortal.DataAccess.DbContext
{
    interface IHospitalCMSContext : IDisposable
    {
        IDbSet<Category> Category { get; set; }
        IDbSet<Language> Language { get; set; }
        IDbSet<Post> Post { get; set; }
        IDbSet<PostSEO> PostSEO { get; set; }
        IDbSet<PostStateHistory> PostStateHistory { get; set; }
        IDbSet<PostTran> PostTran { get; set; }
        IDbSet<Workflow> Workflow { get; set; }
        IDbSet<WorkflowNavigation> WorkflowNavigation { get; set; }
        IDbSet<WorkflowState> WorkflowState { get; set; }
    }
}
