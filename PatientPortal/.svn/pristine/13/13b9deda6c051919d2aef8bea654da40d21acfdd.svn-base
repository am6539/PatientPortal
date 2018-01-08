using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientPortal.CMS.Models
{
    public class CategoriesModel
    {
        public CategoryViewModel CategoryViewModel { get; set; }
        public List<CategoryViewModel> lstCategoryViewModel { get; set; }
    }

    [ProtoContract]
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            Id = Sort = ParentId = 0;
            Name = Image = Handler = string.Empty;
            
        }

        [ProtoMember(1)]
        public byte Id { get; set; }
        [ProtoMember(2)]
        [Required(ErrorMessage = "Bạn cần nhập tên chuyên mục.")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Remote("CheckExist", "Category", HttpMethod = "POST", AdditionalFields = "Id", ErrorMessage = "Tên danh mục đã tồn tại. Vui lòng chọn tên khác.")]
        [Display(Name = "Chuyên mục")]
        public string Name { get; set; }
        [ProtoMember(3)]
        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }
        [ProtoMember(4)]
        [Display(Name = "URL")]
        public string Handler { get; set; }
        [ProtoMember(5)]
        [Display(Name = "Thứ tự")]
        public byte Sort { get; set; }
        [ProtoMember(6, IsRequired = false)]
        [Display(Name = "Thuộc chuyên mục")]
        public byte ParentId { get; set; }
    }
}