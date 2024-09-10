using System;

namespace FlintSoft.CRM.Application.Services;

public record AuthenticationResult(
    Guid Id,
    string FirstName,
    string LastName,
    string Token
);
