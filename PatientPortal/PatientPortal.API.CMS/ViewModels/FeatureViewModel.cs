using ProtoBuf;

namespace PatientPortal.API.CMS.ViewModels
{
    [ProtoContract]
    public partial class FeatureViewModel
    {
        [ProtoMember(1)]
        public byte Id { get; set; }
        [ProtoMember(2)]
        public string Title { get; set; }
        [ProtoMember(3)]
        public string Image { get; set; }
        [ProtoMember(4)]
        public string Description { get; set; }
        [ProtoMember(5)]
        public string Handler { get; set; }
        [ProtoMember(6)]
        public bool IsUsed { get; set; }
    }
}
