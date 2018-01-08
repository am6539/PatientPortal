using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.Models.CORE
{
    public class MailSetting
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Pwd { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool IsSSL { get; set; }
    }
}
