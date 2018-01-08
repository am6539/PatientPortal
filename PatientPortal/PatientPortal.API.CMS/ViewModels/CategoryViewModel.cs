using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace PatientPortal.API.CMS.ViewModels
{
    [ProtoContract]
    public partial class CategoryViewModel
    {
        [ProtoMember(1)]
        public byte Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public string Image { get; set; }
        [ProtoMember(4)]
        public string Handler { get; set; }
        [ProtoMember(5)]
        public byte Sort { get; set; }
        [ProtoMember(6)]
        public byte ParentId { get; set; }
    }
}
