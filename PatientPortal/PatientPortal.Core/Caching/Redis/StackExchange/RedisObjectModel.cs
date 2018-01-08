using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.Caching.Redis.StackExchange
{
    public class RedisServerInfo
    {
        public string Redis_Version { set; get; }
        public string Redis_Mode { set; get; }
        public string OS { set; get; }
        public string Arch_Bits { set; get; }
        public string Process_Id { set; get; }
        public string TCP_Port { set; get; }
    }
}
