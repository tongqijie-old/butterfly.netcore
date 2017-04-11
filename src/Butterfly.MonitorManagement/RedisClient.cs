using System;
using StackExchange.Redis;

namespace Butterfly.MonitorManagement
{
    public class RedisClient
    {
        private static RedisClient _Current = null;

        public static RedisClient Current { get { return _Current ?? (_Current = new RedisClient()); }}

        private ConnectionMultiplexer _Redis;

        private IDatabase _Db;

        private RedisClient()
        {
            _Redis = ConnectionMultiplexer.Connect("127.0.0.1");
            _Db = _Redis.GetDatabase();
        }

        public void Set(string key, string value, TimeSpan? expire)
        {
            _Db.StringSet(key, value, expire);
        }

        public string Get(string key)
        {
            return _Db.StringGet(key);
        }
    }
}