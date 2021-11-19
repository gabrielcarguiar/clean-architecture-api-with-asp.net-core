using CleanArchitecture.WebApi.Infrastructure.Shared.Wrappers.Error.Base;
using System.Net;

namespace CleanArchitecture.WebApi.Infrastructure.Shared.Wrappers.Error
{
    public class ApplicationError : BaseApplicationError
    {
        public string ApplicationMessage { get; }

        internal ApplicationError(HttpStatusCode statusCode, string message) : base(statusCode)
        {
            ApplicationMessage = message;
            BaseMessage = message;
        }

        internal ApplicationError(HttpStatusCode statusCode, string message, object error) : base(statusCode)
        {
            ApplicationMessage = message;
            BaseMessage = error;
        }

        public override string ToString()
        {
            return ApplicationMessage;
        }
    }
}
