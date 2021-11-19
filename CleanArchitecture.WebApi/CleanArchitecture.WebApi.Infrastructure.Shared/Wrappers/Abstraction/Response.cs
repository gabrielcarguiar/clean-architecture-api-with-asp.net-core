using CleanArchitecture.WebApi.Infrastructure.Shared.Wrappers.Error;
using CleanArchitecture.WebApi.Infrastructure.Shared.Wrappers.Error.Base;
using CleanArchitecture.WebApi.Infrastructure.Shared.Wrappers.Interface;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;

namespace CleanArchitecture.WebApi.Infrastructure.Shared.Wrappers.Abstraction
{
    public class Response : IResponse
    {
        private IList<BaseApplicationError> _errors;

        private HttpStatusCode StatusCode { get; set; }

        public HttpStatusCode StatusCodeResponse() => StatusCode;

        public Response()
        {
            StatusCode = HttpStatusCode.OK;
            _errors = new List<BaseApplicationError>();
        }

        public Response(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
            _errors = new List<BaseApplicationError>();
        }

        public Response(Response response)
        {
            StatusCode = response.StatusCodeResponse();
            _errors = response.Errors;
        }

        public Response(string messageError)
        {
            StatusCode = HttpStatusCode.BadRequest;
            _errors = new List<BaseApplicationError>
            {
                new BaseApplicationError(HttpStatusCode.BadRequest)
                {
                    BaseMessage = messageError
                }
            };
        }

        public bool Successful { get => !_errors.Any(); }

        public void AddError(HttpStatusCode statusCode, string messageError)
        {
            AddError(new ApplicationError(statusCode, messageError));
        }

        public void AddError(HttpStatusCode statusCode, string message, object error)
        {
            AddError(new ApplicationError(statusCode, message, error));
        }

        public void AddError(BaseApplicationError error)
        {
            _errors.Add(error);
        }

        public void CopyErrors(Response response)
        {
            if (response.Errors.Any())
            {
                response.Errors.ToList().ForEach(x => AddError(x));
            }
        }

        public IList<BaseApplicationError> Errors { get => new ReadOnlyCollection<BaseApplicationError>(_errors); set { _errors = value; } }
    }
}
