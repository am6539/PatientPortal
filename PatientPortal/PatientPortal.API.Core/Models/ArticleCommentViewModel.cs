using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProtoBuf;

namespace PatientPortal.API.Core.Models
{
    [ProtoContract]
    public class ArticleCommentViewModel
    {
        [ProtoMember(1)]
        public short Id { get; set; }

        [ProtoMember(2)]
        public int ArticleId { get; set; }

        [ProtoMember(3)]
        public DateTime Date { get; set; }

        [ProtoMember(4)]
        public string Detail { get; set; }

        [ProtoMember(5)]
        public string CreatedUser { get; set; }

        [ProtoMember(6)]
        public byte Status { get; set; }

        [ProtoMember(7)]
        public string Author { get; set; }

        [ProtoMember(8)]
        public string ImageProfile { get; set; }
    }
}