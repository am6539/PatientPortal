using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientPortal.PatientServices.Models.Schedule
{
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