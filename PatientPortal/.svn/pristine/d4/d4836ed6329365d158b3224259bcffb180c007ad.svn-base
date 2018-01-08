using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.DbContext
{
    public class CMS_BaseContext<TContext> : System.Data.Entity.DbContext where TContext : System.Data.Entity.DbContext
    {
        static CMS_BaseContext()
        {
             System.Data.Entity.Database.SetInitializer<TContext>(null);
        }

        protected CMS_BaseContext()
            : base("HospitalCMSEntities")
        {
        }
    }
}
