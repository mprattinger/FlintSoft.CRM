using System;
using System.Net;

namespace FlintSoft.CRM.Application.Common.Errors;

public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }

    public string ErrorMessage { get; }
}
