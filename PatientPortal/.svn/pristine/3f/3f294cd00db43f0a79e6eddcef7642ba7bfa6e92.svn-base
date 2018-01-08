using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientPortal.Internal.Models
{
    [ProtoContract]
    public class SystemNotificationViewModel
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Detail { get; set; }
        [ProtoMember(3)]
        public string Date { get; set; }
        [ProtoMember(4)]
        public string Time { get; set; }
        [ProtoMember(5)]
        public string SendFrom { get; set; }
        [ProtoMember(6)]
        public string Link { get; set; }
        [ProtoMember(7)]
        public bool IsRead { get; set; }
    }

    [ProtoContract]
    public class SystemNotificationModel
    {
        [ProtoMember(1)]
        public List<SystemNotificationViewModel> lstUserNotificationViewModel { get; set; }
        [ProtoMember(2)]
        public int TotalItem { get; set; }
    }

    [ProtoContract]
    public class SystemNotificationEditModel
    {
        public SystemNotificationEditModel()
        {
            Detail = Link = string.Empty;
        }
        [ProtoMember(1)]
        public int Id { get; set; }
        [Display(Name = "Nội dung thông báo")]
        [Required(ErrorMessage = "Bạn cần nhập nội dung thông báo")]
        [ProtoMember(2)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Detail { get; set; }
        [Display(Name = "Liên kết")]
        [ProtoMember(3)]
        public string SendFrom { get; set; }
        [ProtoMember(4)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Link { get; set; }
    }
}