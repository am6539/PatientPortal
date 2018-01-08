using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.Models.CORE
{
    public class MessageFolder
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
