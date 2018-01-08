using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.Models.CMS
{
    public partial class GalleryStore
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Img { get; set; }
       
    }
}
