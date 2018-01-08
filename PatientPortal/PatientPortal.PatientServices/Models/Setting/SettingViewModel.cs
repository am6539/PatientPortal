using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace PatientPortal.PatientServices.Models
{
    [ProtoContract]
    public class SettingViewModel
    {
        [ProtoMember(1)]
        public byte Id { get; set; }
        [ProtoMember(2)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [ProtoMember(3)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [ProtoMember(4)]
        [Display(Name = "Từ khóa")]
        public string Keyword { get; set; }
        [ProtoMember(5)]
        [Display(Name = "Loại tài khoản mặc định khi đăng ký")]
        public bool Membership { get; set; }
        [ProtoMember(6)]
        [Display(Name = "Nhóm quyền mặc định khi thêm tài khoản")]
        public string DefaultRole { get; set; }
        [ProtoMember(7)]
        [Display(Name = "Liên kết đăng nhập")]
        public string LoginURL { get; set; }
        [ProtoMember(8)]
        [Display(Name = "Thông báo khóa tài khoản khi truy cập website")]
        public string LockedIPNoteDefault { get; set; }
        [ProtoMember(9)]
        [Display(Name = "Lưu lịch hẹn đăng ký KCB bị hủy")]
        public bool IsSaveCanceledAppointment { get; set; }
        [ProtoMember(10)]
        [Display(Name = "Thời gian khám bệnh")]
        public byte AppointmentIntervalTime { get; set; }
        [ProtoMember(11)]
        [Display(Name = "Thời gian bắt đầu")]
        public int AppointmentStartTime { get; set; }
        [ProtoMember(12)]
        [Display(Name = "Thời gian kết thúc")]
        public int AppointmentEndTime { get; set; }
        [ProtoMember(13)]
        public string AppointmentStartTimeString { get; set; }
        [ProtoMember(14)]
        public string AppointmentEndTimeString { get; set; }
    }
}
