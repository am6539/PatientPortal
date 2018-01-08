using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.API.CMS.ViewModels
{
    [ProtoContract]
    public class AdvertiseViewModel
    {
        [ProtoMember(1)]
        public byte Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public string Description { get; set; }
        [ProtoMember(4)]
        public DateTime StartDate { get; set; }
        [ProtoMember(5)]
        public DateTime EndDate { get; set; }
        [ProtoMember(6)]
        public string Handler { get; set; }
        [ProtoMember(7)]
        public string Resouce { get; set; }

        [ProtoMember(8)]
        public bool IsUsed { get; set; }
        [ProtoMember(9)]
        public byte Type { get; set; }
    }
}