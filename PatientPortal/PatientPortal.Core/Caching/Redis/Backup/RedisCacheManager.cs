using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.Caching.Redis
{
    public class RedisCacheManager : CacheHelper, ICacheManager
    {
        private static IDatabase _db;
        EndPointCollection endpoints = RedisConfig.configOptions.Value.EndPoints;

        public RedisCacheManager()
        {
            _db = RedisConfig.RedisSafeConn.GetDatabase();
        }
        public void Clear()
        {
            var server = _db.Multiplexer.GetServer(endpoints[0]);
            foreach (var item in server.Keys())
                _db.KeyDelete(item);
        }

        public T Get<T>(string key)
        {
            var rValue = _db.SetMembers(key);
            if (rValue.Length == 0)
                return default(T);

            var result = Deserialize<T>(rValue.ToStringArray());
            return result;
        }

        public bool IsSet(string key)
        {
            return _db.KeyExists(key);
        }

        public bool Remove(string key)
        {
            return _db.KeyDelete(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var server = _db.Multiplexer.GetServer(endpoints[0]);
            foreach (var item in server.Keys(pattern: "*" + pattern + "*"))
                _db.KeyDelete(item);
        }

        public void Set(string key, object data, int cacheTime)
        {
            if (data == null)
                return;

            var entryBytes = Serialize(data);
            _db.SetAdd(key, entryBytes);

            var expiresIn = TimeSpan.FromMinutes(cacheTime);

            if (cacheTime > 0)
                _db.KeyExpire(key, expiresIn);
        }
    }
}
