using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.Caching.Redis.StackExchange.Extensions
{
    internal static class RedisDatabaseExtensions
    {
        public static void FlushDatabase(this IDatabase db)
        {
            var endPoints = db.Multiplexer.GetEndPoints();

            foreach (EndPoint endpoint in endPoints)
            {
                var server = db.Multiplexer.GetServer(endpoint);

                server.FlushDatabase();
            }
        }
    }
}
