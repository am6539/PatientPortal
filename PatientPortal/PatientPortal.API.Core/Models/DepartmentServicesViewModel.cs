
using ProtoBuf;

namespace PatientPortal.API.Core.Models
{
    [ProtoContract]
    public partial class DepartmentServicesViewModel
    {
        [ProtoMember(1)]
        public short Id { get; set; }
        [ProtoMember(2)]
        public short DepartmentId { get; set; }
        [ProtoMember(3)]
        public string Name { get; set; }
        [ProtoMember(4)]
        public double Price{ get; set; }
        [ProtoMember(5)]
        public byte Category { get; set; }
    }
}
