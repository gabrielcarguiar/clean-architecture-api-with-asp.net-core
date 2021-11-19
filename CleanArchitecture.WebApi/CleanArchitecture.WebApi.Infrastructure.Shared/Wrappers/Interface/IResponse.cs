using CleanArchitecture.WebApi.Infrastructure.Shared.Wrappers.Error.Base;
using System.Net;

namespace CleanArchitecture.WebApi.Infrastructure.Shared.Wrappers.Interface
{
    public interface IResponse
    {
        public void AddError(HttpStatusCode statusCode, string message);

        public void AddError(BaseApplicationError error);
    }
}
