using System;
using System.Net;

namespace FlintSoft.CRM.Application.Common.Errors;

public interface IError
{
    public HttpStatusCode StatusCode { get; }

    public string ErrorMessage { get; }
}
