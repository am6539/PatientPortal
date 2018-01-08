using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.DataAccess.DbContext
{
    public class Core_BaseContext<TContext> : System.Data.Entity.DbContext where TContext : System.Data.Entity.DbContext
    {
        static Core_BaseContext()
        {
             System.Data.Entity.Database.SetInitializer<TContext>(null);
        }

        protected Core_BaseContext()
            : base("HospitalCoreEntities")
        {
        }
    }
}
