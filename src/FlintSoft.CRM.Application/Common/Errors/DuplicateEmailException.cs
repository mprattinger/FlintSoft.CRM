using System;
using System.Net;

namespace FlintSoft.CRM.Application.Common.Errors;

public class DuplicateEmailException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "User already exists";
}
