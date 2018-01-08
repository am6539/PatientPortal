using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.Models.CMS
{
    public partial class Gallery
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Highlight { get; set; }
        public string Img { get; set; }
        public string YoutubeURL { get; set; }
        public string Date { get; set; }
        public short DepartmentId { get; set; }
        public bool IsMultiple { get; set; }
    }
}
