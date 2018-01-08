using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.Models.CMS
{
    public class Advertise
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Handler { get; set; }
        public string Resouce { get; set; }
        public bool IsUsed { get; set; }
        public byte Type { get; set; }
    }
}
