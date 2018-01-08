﻿using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientPortal.CMS.Models
{
    [ProtoContract]
    public class AdvertiseViewModel : IValidatableObject
    {
        [ProtoMember(1)]
        public byte Id { get; set; }

        [ProtoMember(2)]
        [Display(Name = "Tiêu đề")]
        //[Remote("CheckExist", "Slider", HttpMethod = "POST", AdditionalFields = "Id", ErrorMessage = "Tiêu đề đã tồn tại. Vui lòng nhập lại.")]
        [Required(ErrorMessage = "Bạn cần nhập tên")]
        public string Name { get; set; }

        [ProtoMember(3)]
        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "Bạn cần nhập mô tả")]
        public string Description { get; set; }

        [ProtoMember(4)]
        [Display(Name = "Ngày bắt đầu")]
        [Required(ErrorMessage = "Bạn cần nhập ngày bắt đầu")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [ProtoMember(5)]
        [Display(Name = "Ngày hết hạn")]
        [Required(ErrorMessage = "Bạn cần nhập ngày hết hạn")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [ProtoMember(6)]
        [Required(ErrorMessage = "Bạn cần nhập link")]
        [Display(Name = "URL")]
        public string Handler { get; set; }

        [ProtoMember(7)]
        [Display(Name = "Resouce")]
        public string Resouce { get; set; }

        [ProtoMember(8)]
        [Display(Name = "Hiển thị")]
        public bool IsUsed { get; set; }

        [ProtoMember(9)]
        [Display(Name = "Loại")]
        public byte Type { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndDate < StartDate)
            {
                yield return
                  new ValidationResult(errorMessage: "Ngày bắt đầu phải nhỏ hơn ngày hết hạn",
                                       memberNames: new[] { "EndDate" });
            }
        }
    }
}