using System;

namespace FlintSoft.CRM.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            "firstName",
            "lastName",
            "token"
        );
    }

    public RegistrationResult Register(string firstName, string lastName, string email, string password)
    {
        return new RegistrationResult(
            Guid.NewGuid(),
            firstName,
            lastName
        );
    }
}
