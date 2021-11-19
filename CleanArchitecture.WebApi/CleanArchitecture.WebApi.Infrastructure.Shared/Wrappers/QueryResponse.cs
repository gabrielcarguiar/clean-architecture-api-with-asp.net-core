using CleanArchitecture.WebApi.Infrastructure.Shared.Wrappers.Abstraction;
using MediatR;
using System.Net;

namespace CleanArchitecture.WebApi.Infrastructure.Shared.Wrappers
{
    public class QueryResponse<T> : Response, IRequest<T>
    {
        public QueryResponse()
        {
            SetMessage(default);
        }

        [Newtonsoft.Json.JsonConstructor]
        public QueryResponse(T message)
        {
            SetMessage(message);
        }

        public QueryResponse(HttpStatusCode statusCode, string messageError) : base(statusCode)
        {
            AddError(statusCode, messageError);
        }

        public QueryResponse(HttpStatusCode statusCode, string message, object error) : base(statusCode)
        {
            AddError(statusCode, message, error);
        }

        public QueryResponse(Response response) : base(response)
        {
        }

        private T message;

        //public object Message => Successful ? message : null;

        public T GetMessage()
        {
            return message;
        }

        public void SetMessage(T value)
        {
            message = value;
        }
    }
}
