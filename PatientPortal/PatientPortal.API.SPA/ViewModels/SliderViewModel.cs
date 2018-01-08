using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.API.SPA.ViewModels
{
    public class SliderViewModel
    {
        public short Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime ExpiredDate { get; set; }
        public bool IsUsed { get; set; }
    }
}