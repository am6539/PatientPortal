using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.DataAccess.EntityFramework;

namespace PatientPortal.DataAccess.DbContext
{
    public partial class HospitalCMSContext : CMS_BaseContext<HospitalCMSContext>, IHospitalCMSContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        public virtual IDbSet<Category> Category { get; set; }
        public virtual IDbSet<Language> Language { get; set; }
        public virtual IDbSet<Post> Post { get; set; }
        public virtual IDbSet<PostSEO> PostSEO { get; set; }
        public virtual IDbSet<PostStateHistory> PostStateHistory { get; set; }
        public virtual IDbSet<PostTran> PostTran { get; set; }
        public virtual IDbSet<Workflow> Workflow { get; set; }
        public virtual IDbSet<WorkflowNavigation> WorkflowNavigation { get; set; }
        public virtual IDbSet<WorkflowState> WorkflowState { get; set; }
    }
}
