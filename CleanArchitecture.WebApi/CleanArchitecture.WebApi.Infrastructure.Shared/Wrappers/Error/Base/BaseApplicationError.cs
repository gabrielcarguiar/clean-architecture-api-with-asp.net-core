using Newtonsoft.Json;
using System.Net;

namespace CleanArchitecture.WebApi.Infrastructure.Shared.Wrappers.Error.Base
{
    public class BaseApplicationError
    {
        public BaseApplicationError(HttpStatusCode statusCode)
        {
            HttpStatusCode = statusCode;
        }

        public HttpStatusCode HttpStatusCode { get; }

        [JsonProperty("Message")]
        public object BaseMessage { get; set; }
    }
}
