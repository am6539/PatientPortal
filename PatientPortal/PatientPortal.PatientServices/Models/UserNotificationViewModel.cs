using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.PatientServices.Models
{
    [ProtoContract]
    public class UserNotificationViewModel
    {
        [ProtoMember(1)]
        public string Id { get; set; }

        [ProtoMember(2)]
        public string Detail { get; set; }

        [ProtoMember(3)]
        public string Date { get; set; }

        [ProtoMember(4)]
        public string Time { get; set; }

        [ProtoMember(5)]
        public string UserId { get; set; }

        [ProtoMember(6)]
        public bool IsRead { get; set; }
    }

    [ProtoContract]
    public class UserNotificationModel
    {
        [ProtoMember(1)]
        public List<UserNotificationViewModel> lstUserNotificationViewModel { get; set; }
        [ProtoMember(2)]
        public int TotalItem { get; set; }
    }
}