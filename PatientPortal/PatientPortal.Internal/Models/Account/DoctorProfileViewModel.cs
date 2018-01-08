using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientPortal.Internal.Models
{
    [ProtoContract]
    public class DoctorProfileViewModel
    {
        public DoctorProfileViewModel()
        {
            Speciality = Degrees = Training = Office = Workdays = Name = string.Empty;
        }
        [ProtoMember(1)]
        public string UserId { get; set; }
        [ProtoMember(2)]
        [Display(Name = "Chuyên môn")]
        public string Speciality { get; set; }
        [ProtoMember(3)]
        [Display(Name = "Bằng cấp")]
        public string Degrees { get; set; }
        [ProtoMember(4)]
        [Display(Name = "Kinh nghiệm")]
        public string Training { get; set; }
        [ProtoMember(5)]
        [Display(Name = "Đơn vị")]
        public string Office { get; set; }
        [ProtoMember(6)]
        [Display(Name = "Ngày làm việc")]
        public string Workdays { get; set; }
        [ProtoMember(7)]
        [Display(Name = "Họ tên")]
        public string Name { get; set; }
        [ProtoMember(8)]
        [Display(Name = "Ảnh đại diện")]
        public byte[] Image { get; set; }
        [ProtoMember(9)]
        [Display(Name = "Chuyên khoa")]
        public byte DepartmentId { get; set; }
    }

    [ProtoContract]
    public class DoctorProfileEditModel
    {
        [ProtoMember(1)]
        public string UserId { get; set; }
        [ProtoMember(2)]
        public string Speciality { get; set; }
        [ProtoMember(3)]
        public string Degrees { get; set; }
        [ProtoMember(4)]
        public string Training { get; set; }
        [ProtoMember(5)]
        public string Office { get; set; }
        [ProtoMember(6)]
        public string Workdays { get; set; }
        [ProtoMember(7)]
        public byte DepartmentId { get; set; }
    }
}