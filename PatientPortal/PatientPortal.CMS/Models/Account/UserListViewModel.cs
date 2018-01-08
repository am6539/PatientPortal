using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientPortal.CMS.Models.Account
{
    [ProtoContract]
    public class UserListViewModel
    {
        [ProtoMember(1)]
        public string Id { get; set; }
        [ProtoMember(2)]
        [Display(Name = "Tên người dùng")]
        public string Name { get; set; }
        [ProtoMember(3)]
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }
        [ProtoMember(4)]
        [Display(Name = "Email đăng ký")]
        public string Email { get; set; }
        [ProtoMember(5)]
        [Display(Name = "Hình đại diện")]
        public string Image { get; set; }
        [ProtoMember(6)]
        [Display(Name = "Loại tài khoản")]
        public string GroupMember { get; set; }
    }

    public class ChangePasswordBindingModel
    {
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu cũ.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu cũ")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Mật khẩu mới không được để trống.")]
        [StringLength(100, ErrorMessage = "Độ dài tối thiểu của {0} phải là {2} ký tự.", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}",
            ErrorMessage = "Mật khẩu phải chứa ít nhất một ký tự hoa, một ký tự thường, một số và một ký tự đặc biệt.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu mới")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận lại mật khẩu mới")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "Mật khẩu mới và mật khẩu mới nhập lại không giống nhau.")]
        public string ConfirmPassword { get; set; }
    }

    [ProtoContract]
    public class UserProfileViewModel
    {
        [ProtoMember(1)]
        [Required(ErrorMessage = "Chưa chọn tài khoản cần cập nhật thông tin.")]
        [Display(Name = "Tài khoản")]
        public string UserId { get; set; }
        [ProtoMember(2)]
        [Required(ErrorMessage = "Bạn cần chọn mục tin hợp lệ.")]
        [StringLength(10, ErrorMessage = "Độ dài tối thiểu của {0} phải là {2} ký tự.", MinimumLength = 2)]
        [Display(Name = "Mục tin")]
        public string TabCode { get; set; }
        [ProtoMember(3)]
        [Required(ErrorMessage = "Bạn chưa nhập nội dung mô tả thông tin.")]
        [Display(Name = "Mô tả")]
        [AllowHtml]
        public string Description { get; set; }
    }
}