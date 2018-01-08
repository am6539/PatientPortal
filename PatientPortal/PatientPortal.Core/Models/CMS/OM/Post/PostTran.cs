using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.Models.CMS
{
    public partial class PostTran
    {
        public int PostId { get; set; }
        public byte LanguageId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public string Tag { get; set; }

        //public virtual Language Language { get; set; }
        //public virtual Post Post { get; set; }
    }
}
