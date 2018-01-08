using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.API.SPA.ViewModels
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Handler { get; set; }
        public string Img { get; set; }
        public int Sort { get; set; }
    }
}