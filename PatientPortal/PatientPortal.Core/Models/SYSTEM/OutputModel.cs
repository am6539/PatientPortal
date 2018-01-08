using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.Models.SYSTEM
{
    public class OutputModel
    {
        public string TName { get; set; }
        public DbType TValue { get; set; }
    }

    public class ReturnOuputModel
    {
        public string TName { get; set; }
        public object TValue { get; set; }
    }
}
