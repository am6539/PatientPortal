using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.Caching.Redis
{
    public static class RedisConfiguration
    {
        public static bool IsRedisCache = (Convert.ToInt32(ConfigurationManager.AppSettings["TimeExpried"]) == 0 ? false : true);
    }
}
