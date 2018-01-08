using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.API.SPA.ViewModels
{
    public class ListQAViewModel
    {
        public List<QAViewModel> ListViewModel { get; set; }
        public int TotalItem { get; set; }
    }
}