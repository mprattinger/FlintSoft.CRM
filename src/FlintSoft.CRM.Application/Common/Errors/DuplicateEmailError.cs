using System;
using System.Net;
using FluentResults;

namespace FlintSoft.CRM.Application.Common.Errors;

public class DuplicateEmailError() : IError
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public List<IError> Reasons => throw new NotImplementedException();

    public string Message => "User already exists";

    public Dictionary<string, object> Metadata => throw new NotImplementedException();
}
