using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.CMS.Models
{
    public class AccessPostFilterViewModel
    {
        public int Id { get; set; }
        public string LanguageCode { get; set; }
        public byte CategoryId { get; set; }

        public List<AccessPostViewModel> AccessPostViewModel { get; set; }
    }
}