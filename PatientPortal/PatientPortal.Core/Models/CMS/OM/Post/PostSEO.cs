using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.Models.CMS
{
    public partial class PostSEO
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Canonical { get; set; }
        public string BreadcrumbsTitle { get; set; }
        public byte MetaRobotIndex { get; set; }
        public byte MetaRobotFollow { get; set; }
        public byte MetaRobotAdvanced { get; set; }

        public virtual Post Post { get; set; }
    }
}
