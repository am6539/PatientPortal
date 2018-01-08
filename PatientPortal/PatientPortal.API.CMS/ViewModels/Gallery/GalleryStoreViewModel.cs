using ProtoBuf;

namespace PatientPortal.API.CMS.ViewModels
{
    [ProtoContract]
    public partial class GalleryStoreViewModel
    {
        [ProtoMember(1)]
        public string Id { get; set; }
        [ProtoMember(2)]
        public string ParentId { get; set; }
        [ProtoMember(3)]
        public string Img { get; set; }
    }
}