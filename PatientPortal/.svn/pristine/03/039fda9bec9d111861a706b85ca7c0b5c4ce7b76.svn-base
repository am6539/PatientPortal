using System.ComponentModel.DataAnnotations;
using ProtoBuf;

namespace PatientPortal.API.Identity.Models
{
    [ProtoContract]
    public class Role
    {
        [Key]
        [ProtoMember(1)]
        public string Id { get; set; }
        [ProtoMember(2)]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }
    }
}