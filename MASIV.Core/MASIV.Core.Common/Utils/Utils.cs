using Newtonsoft.Json;

namespace MASIV.Core.Common.Utils
{
    public static class Utils
    {
        public static string CreateMessageError(string message)
        {
            return JsonConvert.SerializeObject(
                new ResponseError
                {
                    Message = message,
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                }
                );
        }
    }
}
