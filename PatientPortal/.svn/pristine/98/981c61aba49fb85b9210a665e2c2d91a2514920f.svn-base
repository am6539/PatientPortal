using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientPortal.API.Identity.Models
{
    [ProtoContract]
    public class PermissionRole
    {
    
        [Key, Column("PermissionId", Order = 0)]
        [ProtoMember(1)]
        public string PermissionId { get; set; }
        [Key, Column("RoleId", Order = 1)]
        [ProtoMember(2)]
        public string RoleId { get; set; }
        public virtual Permission Permission { get; set; }
    }
}