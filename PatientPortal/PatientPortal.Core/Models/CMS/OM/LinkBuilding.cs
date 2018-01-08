using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.Models.CMS
{
    public partial class LinkBuilding
    {
        public short Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public bool IsUsed { get; set; }

    }
}
