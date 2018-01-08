using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.Caching.Redis
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        void Set(string key, object data, int cacheTime);
        bool IsSet(string key);
        bool Remove(string key);
        void RemoveByPattern(string pattern);
        void Clear();
    }
}
