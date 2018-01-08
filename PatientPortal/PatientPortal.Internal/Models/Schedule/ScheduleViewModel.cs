using ProtoBuf;
using System;
using System.ComponentModel.DataAnnotations;

namespace PatientPortal.Internal.Models.Schedule
{
    [ProtoContract]
    public class ScheduleViewModel
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public string Title { get; set; }

        [ProtoMember(3)]
        public DateTime Start { get; set; }

        [ProtoMember(4)]
        public DateTime End { get; set; }

        [ProtoMember(5)]
        public string Detail { get; set; }
        [ProtoMember(6)]
        public string UserId { get; set; }
    }

    public class ScheduleMultipleViewModel
    {
        public CreateScheduleViewModel CreateScheduleViewModel { get; set; }
        public ScheduleFilter ScheduleFilter { get; set; }
    }

    [ProtoContract]
    public class CreateScheduleViewModel
    {
        public CreateScheduleViewModel()
        {
            IsExamine = true;
        }

        [ProtoMember(1)]
        public int Id { get; set; }

        [Display(Name ="Tiêu đề")]
        [ProtoMember(2)]
        public string Title { get; set; }

        [ProtoMember(3)]
        public byte Priority { get; set; }

        [Display(Name = "Nội dung")]
        [ProtoMember(4)]
        public string Detail { get; set; }

        [ProtoMember(5)]
        public bool IsAlarm { get; set; }

        [Display(Name = "Thời gian bắt đầu")]
        [ProtoMember(6)]
        public DateTime Start { get; set; }

        [Display(Name = "Thời gian kết thúc")]
        [ProtoMember(7)]
        public DateTime End { get; set; }

        [ProtoMember(8)]
        public string Color { get; set; }

        [ProtoMember(9)]
        [Display(Name = "Là thời gian khám bệnh")]
        public bool IsExamine { get; set; }
        [Display(Name ="Nhân viên")]

        [ProtoMember(10)]
        public string UserId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string StartDate { get; set; }
    }

    public class ScheduleFilter
    {
        public string UserId { get; set; }
        [Display(Name = "Ngày bắt đầu")]
        [Required(ErrorMessage = "Bạn cần nhập ngày bắt đầu")]
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }
        [Display(Name = "Ngày kết thúc")]
        [Required(ErrorMessage = "Bạn cần nhập ngày kết thúc")]
        [DataType(DataType.Date)]
        public DateTime End { get; set; }
    }
}