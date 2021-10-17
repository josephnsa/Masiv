using StackExchange.Redis;
namespace MASIV.Core.Common.Interfaces
{
    public interface ICommonRepository
    {
        HashEntry[] Get(string key);
        string GetById(string key, string fieldId);
        bool Post(string hashKey, string fieldKey, string value);

    }
}