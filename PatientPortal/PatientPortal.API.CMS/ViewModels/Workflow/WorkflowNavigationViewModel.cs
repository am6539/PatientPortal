using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.API.CMS.ViewModels
{
    [ProtoContract]
    public class WorkflowNavigationViewModel
    {
        [ProtoMember(1)]
        public short WorkflowStateId { get; set; }
        [ProtoMember(2)]
        public short NextWorkflowStateId { get; set; }
        [ProtoMember(3)]
        public bool IsUsed { get; set; }
    }
}