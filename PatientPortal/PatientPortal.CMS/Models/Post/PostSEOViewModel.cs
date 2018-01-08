using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.CMS.Models
{
    [ProtoContract]
    public partial class PostSEOViewModel
    {
        [ProtoMember(1)]
        public int PostId { get; set; }
        [ProtoMember(2)]
        public string Title { get; set; }
        [ProtoMember(3)]
        public string Description { get; set; }
        [ProtoMember(4)]
        public string Canonical { get; set; }
        [ProtoMember(5)]
        public string BreadcrumbsTitle { get; set; }
        [ProtoMember(6)]
        public byte MetaRobotIndex { get; set; }
        [ProtoMember(7)]
        public byte MetaRobotFollow { get; set; }
        [ProtoMember(8)]
        public byte MetaRobotAdvanced { get; set; }

        [ProtoMember(9)]
        public virtual PostViewModel Post { get; set; }
    }
}