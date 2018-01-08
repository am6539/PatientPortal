using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.API.Core.Models
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
    public class SystemNotificationEditModel
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
    }

    [ProtoContract]
    public class SystemNotificationModel
    {
        [ProtoMember(1)]
        public List<SystemNotificationViewModel> lstUserNotificationViewModel { get; set; }
        [ProtoMember(2)]
        public int TotalItem { get; set; }
    }
}