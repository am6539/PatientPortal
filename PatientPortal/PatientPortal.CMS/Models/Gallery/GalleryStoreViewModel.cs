using ProtoBuf;
using System.Collections.Generic;

namespace PatientPortal.CMS.Models
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

    public partial class GalleryUploader
    {
        public string Id { get; set; }
        public string Title { get; set; }
    }

    public class GalleryStoreModel
    {
        public GalleryUploader ParentModel { get; set; }
        public List<GalleryStoreViewModel> lstGalleryStore { get; set; }
    }
}