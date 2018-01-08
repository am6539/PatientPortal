using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientPortal.Internal.Models
{
    public class DepartmentServicesModel
    {
        public DepartmentServicesViewModel Services { get; set; }
        public List<DepartmentServicesViewModel> lstServices { get; set; }
    }
   
    [ProtoContract]
    public partial class DepartmentServicesViewModel
    {
        public DepartmentServicesViewModel()
        {
            Name = string.Empty;
            Category = 1;
        }
        [ProtoMember(1)]
        public short Id { get; set; }
        [ProtoMember(2)]
        [Display(Name = "Chuyên khoa")]
        [Required(ErrorMessage = "Bạn chưa chọn chuyên khoa.")]
        public short DepartmentId { get; set; }
        [ProtoMember(3)]
        [Display(Name = "Tên dịch vụ")]
        [Required(ErrorMessage = "Bạn cần nhập tên dịch vụ.")]
        public string Name { get; set; }
        [ProtoMember(4)]
        [Display(Name = "Đơn giá")]
        [Required(ErrorMessage = "Bạn cần nhập đơn giá dịch vụ.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        public double Price { get; set; }
        [ProtoMember(5)]
        [Display(Name = "Loại dịch vụ")]
        [Required(ErrorMessage = "Bạn cần chọn loại dịch vụ.")]
        public byte Category { get; set; }
    }
}