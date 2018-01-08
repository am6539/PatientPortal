using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.API.SPA.ViewModels
{
    public class QAViewModel
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
        public string DoctorName { get; set; }
    }
}