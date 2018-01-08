using LinqToExcel.Attributes;
using System;

namespace PatientPortal.Internal.Models.Schedule
{
    public class ScheduleExcelViewModel
    {
        [ExcelColumn("Tiêu đề")]
        public string Title { get; set; }

        public byte Priority { get; set; }

        [ExcelColumn("Chi tiết")]
        public string Detail { get; set; }

        public bool IsAlarm { get; set; }

        [ExcelColumn("Bắt đầu")]
        public DateTime Start { get; set; }

        [ExcelColumn("Kết thúc")]
        public DateTime End { get; set; }

        [ExcelColumn("Màu")]
        public string Color { get; set; }

        public bool IsExamine { get; set; }

        [ExcelColumn("Email")]
        public string UserId { get; set; }
    }
}