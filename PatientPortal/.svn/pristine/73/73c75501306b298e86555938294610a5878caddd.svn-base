using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using System.Configuration;

namespace PatientPortal.Domain.Caching.Redis
{
    public class RedisConfig
    {
        public static Lazy<ConfigurationOptions> configOptions = new Lazy<ConfigurationOptions>(() =>
        {
            string host = ConfigurationManager.AppSettings["redis:cache"].ToString();
            var configOptions = new ConfigurationOptions();

            configOptions.EndPoints.Add(host);
            configOptions.ClientName = "SafeRedisConnection";
            configOptions.ConnectTimeout = 100000;
            configOptions.SyncTimeout = 100000;
            configOptions.AbortOnConnectFail = false;

            return configOptions;
        });

        private static Lazy<ConnectionMultiplexer> conn
            = new Lazy<ConnectionMultiplexer>(
                () => ConnectionMultiplexer.Connect(configOptions.Value));

        public static ConnectionMultiplexer RedisSafeConn
        {
            get
            {
                return conn.Value;
            }
        }
    }
}
