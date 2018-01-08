using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.CMS.Models
{
    [ProtoContract]
    public partial class PostStateHistoryViewModel
    {
        public PostStateHistoryViewModel() {
            WorkflowStateId = 2;
            Note = string.Empty;
        }

        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public int PostId { get; set; }
        [ProtoMember(3)]
        public byte WorkflowStateId { get; set; }
        [ProtoMember(4)]
        public string UserId { get; set; }
        [ProtoMember(5)]
        public string Note { get; set; }
        //[ProtoMember(6)]
        //public string CreatedDate { get; set; }

        //[ProtoMember(7)]
        //public virtual PostViewModel Post { get; set; }
    }
}