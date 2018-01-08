using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientPortal.Internal.Models
{
    public class PermissionModel
    {
        public PermissionViewModel PermissionViewModel { get; set; }
        public List<PermissionViewModel> lstPermissionViewModel { get; set; }
    }

    [ProtoContract]
    public class PermissionViewModel
    {
        public PermissionViewModel()
        {
            this.Id = Guid.NewGuid().ToString();
            Name = Description = string.Empty;
        }
        [ProtoMember(1)]
        public string Id { get; set; }
        [ProtoMember(2)]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Mã chi tiết quyền")]
        public string Name { get; set; }
        [ProtoMember(3)]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        public virtual ICollection<PermissionRoleViewModel> PermissionRoles { get; set; }
    }

    public class PermissionRoleViewModel
    {
        [Display(Name = "Chi tiết quyền")]
        public string PermissionId { get; set; }
        [Display(Name = "Nhóm tài khoản")]
        public string RoleId { get; set; }
    }
}