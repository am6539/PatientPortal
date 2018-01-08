using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace PatientPortal.Domain.Models.HIS
{
    public class SharedFile
    {
        public string PatientId { get; set; }
        public string Type { get; set; }
        public string No { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }

        // {"PatientId": "16018002","Type":"DONTHUOC", "Date":"01/01/2017", "No":"10001","Title":"", "Path": "16018002_DONTHUOC_10001_1.PDF"}
        // {"PatientId": "16018002","Type":"KET_QUA_XN", "Date":"01/01/2017", "No":"10001","Title":"Kết quả xét nghiệm", "Path": "16018002_10001_1611000462.PDF"}
    }
}
