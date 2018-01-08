using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientPortal.CMS.Models
{
    [ProtoContract]
    public partial class PostTranViewModel
    {
        [ProtoMember(1)]
        public int PostId { get; set; }

        [ProtoMember(2)]
        [Display(Name = "Ngôn ngữ")]
        [Required(ErrorMessage = "Vui lòng chọn ngôn ngữ")]
        public byte LanguageId { get; set; }

        [ProtoMember(3)]
        [Required(ErrorMessage = "Bạn chưa nhập tiêu đề bài viết")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [ProtoMember(4)]
        [Required(ErrorMessage = "Bạn chưa nhập nội dung trích dẫn")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Trích dẫn")]
        public string Description { get; set; }

        [ProtoMember(5)]
        [AllowHtml]
        [Required(ErrorMessage = "Bạn chưa nhập nội dung bài viết")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Chi tiết")]
        public string Detail { get; set; }

        [ProtoMember(6)]
        [Display(Name = "Chỉ mục")]
        public string Tag { get; set; }
    }
}