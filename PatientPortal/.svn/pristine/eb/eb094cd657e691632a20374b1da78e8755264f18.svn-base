using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PatientPortal.CMS.Models
{
    [ProtoContract]
    public class WorkflowViewModel
    {
        [ProtoMember(1)]
        public byte Id { get; set; }

        [ProtoMember(2)]
        [Display(Name = "Nhập tên")]
        [Remote("CheckExist", "Workflow", HttpMethod = "POST", AdditionalFields = "Id", ErrorMessage = "Tên đã tồn tại. Vui lòng chọn tên khác!!!")]
        [Required(ErrorMessage = "Bạn cần nhập tên workflow.")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Name { get; set; }
    }
}