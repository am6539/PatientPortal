using System.ComponentModel.DataAnnotations;
using ProtoBuf;

namespace PatientPortal.API.Core.Models
{
    [ProtoContract]
    public class SurveyAnswersViewModel
    {
        [ProtoMember(1)]
        [Display(Name = "Id câu trả lời")]
        public byte Id { get; set; }
        [ProtoMember(2)]
        [Display(Name = "Id câu hỏi")]
        public string QuestionId { get; set; }
        [ProtoMember(3)]
        [Display(Name = "Trả lời")]
        public string Answer { get; set; }
        [ProtoMember(4)]
        [Display(Name = "Nhãn điểm thấp")]
        public string LowScore { get; set; }
        [ProtoMember(5)]
        [Display(Name = "Nhãn điểm cao")]
        public string HightScore { get; set; }
    }
}