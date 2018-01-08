using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.Utilities
{
    public static class GlobalVariables
    {
        public static string DapperInstance(short index = 1)
        {
            switch (index)
            {
                case 1:
                    return "Hospital.CMS";
                default:
                    return "Hospital.Core";
            }
        }

        public static int IsTransParameter = 0;

        public static string NULL_PARAMETER = "";

        public static byte Id_Configuration = 1;
    }
}
