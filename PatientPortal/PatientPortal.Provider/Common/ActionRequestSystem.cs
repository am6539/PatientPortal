using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Provider.Common
{
    public static class ARS
    {
        public static string Access { get { return "Access"; } } //Access feature
        public static string Get { get { return "Get"; } } //View data
        public static string Insert { get { return "Insert"; } } //Add new item
        public static string Edit { get { return "Edit"; } } //Edit item
        public static string Delete { get { return "Delete"; } } //Delete item
        public static string Detail { get { return "Detail"; } } //View detail
        public static string Print { get { return "Print"; } } //Print
        public static string Export { get { return "Export"; } } //Export
        public static string Statistic { get { return "Statistic"; } } //Collect
        public static string IgnoredARS { get { return "IgnoredARS"; } } //Ignored ARS
    }
}
