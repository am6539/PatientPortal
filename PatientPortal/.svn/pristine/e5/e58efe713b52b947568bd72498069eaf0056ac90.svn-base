using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.Newtonsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.Caching.Redis.StackExchange
{
    public class JsonNetSerialize: RedisCacheClient
    {
        public JsonNetSerialize()
            : base(new NewtonsoftSerializer())
        {
        }
    }
    //public class JilSerializerTest : RedisCacheClient
    //{
    //    public JilSerializerTest()
    //        : base(new JilSerializer())
    //    {
    //    }
    //}
    //public class ProtobufSerializeTest : RedisCacheClient
    //{
    //    public ProtobufSerializeTest()
    //        : base(new ProtobufSerializer())
    //    {

    //    }
    //}
}
