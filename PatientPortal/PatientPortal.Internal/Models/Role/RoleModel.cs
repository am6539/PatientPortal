using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProtoBuf;

namespace PatientPortal.Internal.Models
{
    public class RoleModel
    {
        public RoleViewModel RoleViewModel { get; set; }
        public List<RoleViewModel> lstRoleViewModel { get; set; }
    }

    [ProtoContract]
    public class RoleViewModel
    {
        [ProtoMember(1)]
        public string Id { get; set; }
        [ProtoMember(2)]
        [Required(ErrorMessage = "Vui lòng nhập tên nhóm tài khoản.")]
        [Display(Name = "Tên nhóm tài khoản")]
        public string Name { get; set; }
    }

    [ProtoContract]
    public class RolePermissionViewModel
    {
        [Key]
        [ProtoMember(1)]
        public string Id { get; set; }
        [ProtoMember(2)]
        [Display(Name = "Tên quyền")]
        public string Name { get; set; }
        [ProtoMember(3)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [ProtoMember(4)]
        public bool IsUsed { get; set; } //Only use in Internal Project
        [ProtoMember(5)]
        [Display(Name = "Nhóm tài khoản")]
        public string RoleId { get; set; }
    }

    [ProtoContract]
    public class RolePermission
    {

        [Key, Column("PermissionId", Order = 0)]
        [ProtoMember(1)]
        public string PermissionId { get; set; }
        [Key, Column("RoleId", Order = 1)]
        [ProtoMember(2)]
        public string RoleId { get; set; }
    }
}