using System;
using System.ComponentModel.DataAnnotations;
using ProtoBuf;

namespace PatientPortal.Internal.Models
{
    [ProtoContract]
    public class OfferAdviseViewModel
    {
        public OfferAdviseViewModel()
        {
            Status = 0;
        }

        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày")]
        public DateTime Date { get; set; }

        [ProtoMember(3)]
        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "Bạn cần nhập ý kiến")]
        public string Detail { get; set; }

        [ProtoMember(4)]
        public string PatientId { get; set; }

        [ProtoMember(5)]
        [Required(ErrorMessage = "Bạn cần nhập tags")]
        [Display(Name = "Tags")]
        public string Tag { get; set; }

        [ProtoMember(6)]
        [Display(Name = "Duyệt")]
        public byte Status { get; set; }

        [ProtoMember(7)]
        [Display(Name = "Ghi chú duyệt")]
        [Required(ErrorMessage = "Bạn cần nhập ghi chú duyệt")]
        public string Message { get; set; }
    }
}