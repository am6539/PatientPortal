using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.Models.CORE.Report
{
    [ProtoContract]
    public class RPAppointment
    {
        [ProtoMember(1)]
        public short No { get; set; }
        [ProtoMember(2)]
        public string PhysicianId { get; set; }
        [ProtoMember(3)]
        public string PhysicianName { get; set; }
        [ProtoMember(4)]
        public DateTime Date { get; set; }
        [ProtoMember(5)]
        public int Time { get; set; }
        [ProtoMember(6)]
        public string DepartmentName { get; set; }
    }
}
