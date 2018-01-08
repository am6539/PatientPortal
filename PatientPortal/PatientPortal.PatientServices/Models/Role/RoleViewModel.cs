using System.ComponentModel.DataAnnotations;
using ProtoBuf;

namespace PatientPortal.PatientServices.Models
{
    [ProtoContract]
    public class RoleViewModel
    {
        [ProtoMember(1)]
        public short Id { get; set; }
        [ProtoMember(2)]
        [Display(Name = "Nhóm quyền")]
        public string Name { get; set; }
    }
}
