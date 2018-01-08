using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.API.Library.ViewModel
{
    [ProtoContract]
    public class FileViewModel
    {
        [ProtoMember(1)]
        public string Url { get; set; }
    }
}