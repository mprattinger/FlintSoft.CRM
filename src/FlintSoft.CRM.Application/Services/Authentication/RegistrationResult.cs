using System;

namespace FlintSoft.CRM.Application.Services;

public record RegistrationResult(
    Guid Id,
    string FirstName,
    string LastName
);
