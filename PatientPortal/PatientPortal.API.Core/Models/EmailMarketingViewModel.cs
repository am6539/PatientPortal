using System;
using System.ComponentModel.DataAnnotations;
using ProtoBuf;

namespace PatientPortal.API.Core.Models
{
    [ProtoContract]
    public class EmailMarketingViewModel
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }

        [ProtoMember(3)]
        public string Detail { get; set; }

        [ProtoMember(4)]
        public bool IsUsed { get; set; }

        [ProtoMember(5)]
        public string CreatedUser { get; set; }

        [ProtoMember(6)]
        public string CreatedDate { get; set; }

        [ProtoMember(7)]
        public string ModifiedUser { get; set; }

        [ProtoMember(8)]
        public string ModifiedDate { get; set; }

        [ProtoMember(9)]
        public string EmailGroupType { get; set; }
    }
}