using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.API.Core.Models
{
    [ProtoContract]
    public class AppointmentViewModel
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public DateTime Date { get; set; }
        [ProtoMember(3)]
        public int Time { get; set; }
        [ProtoMember(4)]
        public int PhysicianId { get; set; }
        [ProtoMember(5)]
        public int PatientId { get; set; }
        [ProtoMember(6)]
        public string Symptom { get; set; }
        [ProtoMember(7)]
        public DateTime CreatedDate { get; set; }
        [ProtoMember(8)]
        public DateTime ModifiedDate { get; set; }
        [ProtoMember(9)]
        public byte Status { get; set; }
    }
}