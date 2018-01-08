using ProtoBuf;

namespace PatientPortal.API.Core.Models
{
    [ProtoContract]
    public class SettingViewModel
    {
        [ProtoMember(1)]
        public byte Id { get; set; }
        [ProtoMember(2)]
        public string Title { get; set; }
        [ProtoMember(3)]
        public string Description { get; set; }
        [ProtoMember(4)]
        public string Keyword { get; set; }
        [ProtoMember(5)]
        public bool Membership { get; set; }
        [ProtoMember(6)]
        public string DefaultRole { get; set; }
        [ProtoMember(7)]
        public string LoginURL { get; set; }
        [ProtoMember(8)]
        public string LockedIPNoteDefault { get; set; }
        [ProtoMember(9)]
        public bool IsSaveCanceledAppointment { get; set; }
        [ProtoMember(10)]
        public byte AppointmentIntervalTime { get; set; }
        [ProtoMember(11)]
        public int AppointmentStartTime { get; set; }
        [ProtoMember(12)]
        public int AppointmentEndTime { get; set; }
        [ProtoMember(13)]
        public string AppointmentStartTimeString { get; set; }
        [ProtoMember(14)]
        public string AppointmentEndTimeString { get; set; }
    }
}
