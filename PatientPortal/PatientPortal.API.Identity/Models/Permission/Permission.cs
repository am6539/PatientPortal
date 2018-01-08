using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PatientPortal.API.Identity.Models
{
    [ProtoContract]
    public class Permission
    {
        public Permission()
        {
            this.Id = Guid.NewGuid().ToString();
            this.PermissionRoles = new HashSet<PermissionRole>();
        }
        [Key]
        [ProtoMember(1)]
        public string Id { get; set; }
        [ProtoMember(2)]
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [ProtoMember(3)]
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public virtual ICollection<PermissionRole> PermissionRoles { get; set; }

    }

    //[ProtoContract]
    //public class PermissionRole
    //{
    //    [Key, Column("PermissionId", Order = 0)]
    //    [ProtoMember(1)]
    //    public string PermissionId { get; set; }
    //    [Key, Column("RoleId", Order = 1)]
    //    [ProtoMember(2)]
    //    public string RoleId { get; set; }
    //}

    [ProtoContract]
    public class PermissionViewModel
    {
        [Key]
        [ProtoMember(1)]
        public string Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public string Description { get; set; }
        [ProtoMember(4)]
        public bool IsUsed { get; set; } //Only use in Internal Project
        [ProtoMember(5)]
        public string RoleId { get; set; }
    }
}