using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PatientPortal.Domain.Models.Portal
{
    public static class NamedModule
    {
        public static HtmlString Generate()
        {
            string str = string.Empty;


            return new HtmlString(str);
        }
    }

    public enum NamedType : byte
    {
        List,
        Create,
        Edit,
        Delete,
        View,
        Detail,
        Search
    }
}
