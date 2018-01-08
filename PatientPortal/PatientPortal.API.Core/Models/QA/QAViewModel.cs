using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientPortal.API.Core.Models.QA
{
    [ProtoContract]
    public class QAViewModel
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        [Display(Name = "Ngày hỏi")]
        public DateTime Date { get; set; }

        [ProtoMember(3)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [ProtoMember(4)]
        [Display(Name = "Câu hỏi")]
        public string Question { get; set; }

        [ProtoMember(5)]
        [Display(Name = "Tên người hỏi")]
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
        public string Answer { get; set; }

        [ProtoMember(10)]
        [Display(Name = "Chuyên khoa")]
        public string Department { get; set; }
    }
}