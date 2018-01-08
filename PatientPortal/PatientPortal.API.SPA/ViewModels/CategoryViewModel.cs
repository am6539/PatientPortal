using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.API.SPA.ViewModels
{
    public class CategoryViewModel
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Handler { get; set; }
        public byte Sort { get; set; }
        public byte ParentId { get; set; }
    }
}