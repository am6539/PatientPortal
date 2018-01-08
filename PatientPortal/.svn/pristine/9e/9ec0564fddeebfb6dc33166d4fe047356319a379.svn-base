using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientPortal.Internal.Models
{
    [ProtoContract]
    public class QAViewModel
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(3)]
        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Bạn cần nhập tiêu đề câu hỏi")]
        public string Title { get; set; }

        [ProtoMember(4)]
        [Display(Name = "Câu hỏi")]
        [Required(ErrorMessage = "Bạn cần nhập nội dung câu hỏi")]
        public string Question { get; set; }

        [ProtoMember(5)]
        [Display(Name = "Tên người hỏi")]
        [Required(ErrorMessage = "Bạn cần nhập tên người hỏi")]
        public string Name { get; set; }

        [ProtoMember(6)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [ProtoMember(7)]
        [Display(Name = "Điện thoại")]
        public string Phone { get; set; }

        [ProtoMember(8)]
        public string DoctorId { get; set; }

        [ProtoMember(9)]
        [Display(Name = "Trả lời")]
        [Required(ErrorMessage = "Bạn cần nhập trả lời")]
        public string Answer { get; set; }

        [ProtoMember(10)]
        [Display(Name = "Chuyên khoa")]
        public string Department { get; set; }
    }
}