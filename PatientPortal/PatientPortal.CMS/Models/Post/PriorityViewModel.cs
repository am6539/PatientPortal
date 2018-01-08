using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.CMS.Models
{
    public class PriorityViewModel
    {
        public byte Id { get; set; }
        public string Name { get; set; }
    }

    public class InitPriority
    {
        public List<PriorityViewModel> InitItemPriority()
        {
            var listPriority = new List<PriorityViewModel>();

            PriorityViewModel item1 = new PriorityViewModel(){ Id = 1, Name = "Tiêu điểm" };
            listPriority.Add(item1);
            PriorityViewModel item2 = new PriorityViewModel() { Id = 2, Name = "Tin hot" };
            listPriority.Add(item2);

            return listPriority;
        }
    }
}

