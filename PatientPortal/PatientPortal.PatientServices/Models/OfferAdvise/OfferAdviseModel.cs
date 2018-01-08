using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientPortal.PatientServices.Models
{
    [ProtoContract]
    public class OfferAdviseViewModel
    {
        public OfferAdviseViewModel()
        {
            Date = DateTime.Now;
            Tag = Message = Detail = string.Empty;
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
        [Display(Name = "Tags")]
        public string Tag { get; set; }

        [ProtoMember(6)]
        public byte Status { get; set; }

        [ProtoMember(7)]
        public string Message { get; set; }

    }

    public class OfferAdviseModel
    {
        public OfferAdviseViewModel OfferAdviseViewModel { get; set; }
        public List<OfferAdviseViewModel> lstOfferAdviseViewModel { get; set; }
    }
}