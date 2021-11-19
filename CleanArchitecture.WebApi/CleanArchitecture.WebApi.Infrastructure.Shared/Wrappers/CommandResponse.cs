using CleanArchitecture.WebApi.Infrastructure.Shared.Wrappers.Abstraction;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace CleanArchitecture.WebApi.Infrastructure.Shared.Wrappers
{
    public class CommandResponse : Response, IRequest<Unit>
    {
        public CommandResponse()
        {
        }

        public CommandResponse(HttpStatusCode statusCode) : base(statusCode)
        {
        }

        [JsonConstructor]
        public CommandResponse(int resourceId) : base(HttpStatusCode.Created)
        {
            ResourceId = resourceId;
        }

        [JsonConstructor]
        public CommandResponse(int resourceId, object data) : base(HttpStatusCode.Created)
        {
            ResourceId = resourceId;
            Data = data;
        }

        public CommandResponse(HttpStatusCode statusCode, int resourceId, object data) : base(statusCode)
        {
            ResourceId = resourceId;
            Data = data;
        }

        public CommandResponse(HttpStatusCode statusCode, string messageError) : base()
        {
            AddError(statusCode, messageError);
        }

        public CommandResponse(HttpStatusCode statusCode, string message, object error) : base()
        {
            AddError(statusCode, message, error);
        }

        public CommandResponse(string messageError) : base(messageError)
        {
        }

        public CommandResponse(Response response) : base(response)
        {
        }

        public int ResourceId { get; set; }

        public object Data { get; set; }
    }
}
