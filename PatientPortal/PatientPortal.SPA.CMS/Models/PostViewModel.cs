using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.SPA.CMS.Models
{
    [ProtoContract]
    public class PostViewModel
    {// Post
        [ProtoMember(1, IsRequired = false)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Image { get; set; }
        [ProtoMember(3)]
        public DateTime PublishDate { get; set; }
        [ProtoMember(4)]
        public string Author { get; set; }
        [ProtoMember(5)]
        public byte WorkflowStateId { get; set; }
        [ProtoMember(6)]
        public byte CategoryId { get; set; }
        [ProtoMember(7)]
        public byte Status { get; set; }
        [ProtoMember(8)]
        public int CreatedBy { get; set; }
        [ProtoMember(9)]
        public int ModifiedBy { get; set; }
        [ProtoMember(10)]
        public byte LanguageId { get; set; }
        [ProtoMember(11)]
        public byte Priority { get; set; }
        [ProtoMember(12)]
        public DateTime ExpiredDate { get; set; }

        // Post SEO
        [ProtoMember(13)]
        public string TitleSEO { get; set; }
        [ProtoMember(14)]
        public string DescriptionSEO { get; set; }
        [ProtoMember(15)]
        public string Canonical { get; set; }
        [ProtoMember(16)]
        public byte MetaRobotIndex { get; set; }
        [ProtoMember(17)]
        public byte MetaRobotFollow { get; set; }
        [ProtoMember(18)]
        public byte MetaRobotAdvanced { get; set; }

        // PostTrans
        [ProtoMember(19)]
        public string TitleTrans { get; set; }
        [ProtoMember(20)]
        public string CategoryName { get; set; }
        [ProtoMember(21)]
        public string DescriptionTrans { get; set; }
        [ProtoMember(22)]
        public string Detail { get; set; }
        [ProtoMember(23)]
        public string Tag { get; set; }

        //parameter PostStateHistory
        [ProtoMember(24)]
        public int UserId { get; set; }
        [ProtoMember(25)]
        public string Note { get; set; }
    }
}