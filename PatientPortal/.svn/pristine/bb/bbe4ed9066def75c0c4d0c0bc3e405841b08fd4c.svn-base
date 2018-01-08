using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ProtoBuf;

namespace PatientPortal.Internal.Models
{
    [ProtoContract]
    public class EmailMarketingViewModel
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        [Display(Name = "Tiêu đề email")]
        [Required(ErrorMessage = "Bạn cần nhập tiêu đề email")]
        public string Name { get; set; }

        [ProtoMember(3)]
        [Display(Name = "Nội dung email")]
        [Required(ErrorMessage = "Bạn cần nhập nội dung email")]
        [AllowHtml]
        public string Detail { get; set; }

        [ProtoMember(4)]
        [Display(Name = "Sử dụng")]
        public bool IsUsed { get; set; }

        [ProtoMember(5)]
        public string CreatedUser { get; set; }

        [ProtoMember(6)]
        public string CreatedDate { get; set; }

        [ProtoMember(7)]
        public string ModifiedUser { get; set; }

        [ProtoMember(8)]
        public string ModifiedDate { get; set; }

        [ProtoMember(9)]
        [Required(ErrorMessage = "Vui lòng chọn nhóm tài khoản nhận email")]
        [Display(Name = "Nhóm tài khoản nhận email")]
        public string EmailGroupType { get; set; }

        public string Type { get; set; }
    }
}