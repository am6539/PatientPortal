using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.Models.CORE
{
    public partial class AppointmentCollection
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Time { get; set; }
        public int AppointmentNo { get; set; }
        public string PatientName { get; set; }
        public string PatientAddress { get; set; }
        public string PatientEmail { get; set; }
        public string PatientPhone { get; set; }
        public byte PatientGender { get; set; }
        public DateTime PatientDoB { get; set; }
        public byte Status { get; set; }
    }
}
