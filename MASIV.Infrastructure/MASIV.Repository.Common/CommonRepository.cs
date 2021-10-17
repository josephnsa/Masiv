using MASIV.Core.Common.Interfaces;
using StackExchange.Redis;
namespace MASIV.Repository.Common
{
    public class CommonRepository : Core.Common.Interfaces.ICommonRepository
    {
        private readonly IDatabase databaseCache;
        public CommonRepository(IDatabase database)
        {
            databaseCache = database;
        }
        public HashEntry[] Get(string key)
        {
            return databaseCache.HashGetAll(key: key);
        }
        public string GetById(string key, string fieldId)
        {
            string result = string.Empty;
            var redisValue = databaseCache.HashGet(key: key, hashField: fieldId);
            if (redisValue != RedisValue.Null)
            {
                result = redisValue.ToString();
            }

            return result;
        }
        public bool Post(string hashKey, string fieldKey, string value)
        {
            return databaseCache.HashSet(key: hashKey, hashField: fieldKey, value: value);
        }
    }
}