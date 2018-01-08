using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.Models.SPA
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte Priority { get; set; }
        public string Detail { get; set; }
        public bool IsAlarm { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Color { get; set; }
        public bool IsExamine { get; set; }
        public string UserId { get; set; }
    }
}
