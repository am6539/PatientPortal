using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientPortal.API.CMS.ViewModels
{
    [ProtoContract]
    public class LanguageViewModel
    {
        [ProtoMember(1)]
        public byte Id { get; set; }
        [ProtoMember(2)]
        [Required]
        public string Code { get; set; }
        [ProtoMember(3)]
        [Required]
        public string Name { get; set; }
        [ProtoMember(4)]
        public byte[] Icon { get; set; }
    }
}