using System.Net;

namespace MASIV.Core.Common.Utils
{
    public class ResponseError
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
