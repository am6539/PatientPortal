using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.Internal.Models
{
    public class JsTreeModel
    {
        public string text;
        public string id;
        public StateNode state;
        public List<JsTreeModel> children;
    }

    public class StateNode
    {
        public bool opened;
        public bool selected;
    }
}