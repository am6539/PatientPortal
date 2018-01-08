using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientPortal.API.Core.Models
{
    [ProtoContract]
    public class ArticleViewModel
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [ProtoMember(3)]
        public string Title { get; set; }

        [ProtoMember(4)]
        public string Detail { get; set; }

        [ProtoMember(5)]
        public string PatientId { get; set; }

        [ProtoMember(6)]
        public byte Status { get; set; }

        [ProtoMember(7)]
        public bool IsClosed { get; set; }

        [ProtoMember(8)]
        public int CountComments { get; set; }

        [ProtoMember(9)]
        public string AuthorName { get; set; }

        [ProtoMember(10)]
        public byte[] ImageProfile { get; set; }
    }

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
        public byte[] ImageProfile { get; set; }
    }
}