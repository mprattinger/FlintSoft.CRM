using System;
using System.Net;

namespace FlintSoft.CRM.Application.Common.Errors;

public record struct DuplicateEmailError() : IError
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "User already exists";
}
