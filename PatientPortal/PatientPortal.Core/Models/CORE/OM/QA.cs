using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.Models.CORE
{
    public class QA
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Question { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DoctorId { get; set; }
        public string Answer { get; set; }
        public string Department { get; set; }
    }
}
