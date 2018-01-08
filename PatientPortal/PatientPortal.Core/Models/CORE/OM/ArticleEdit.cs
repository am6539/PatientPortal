using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.Models.CORE
{
    public class ArticleEdit
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string PatientId { get; set; }
        public byte Status { get; set; }
        public bool IsClosed { get; set; }
    }
}
