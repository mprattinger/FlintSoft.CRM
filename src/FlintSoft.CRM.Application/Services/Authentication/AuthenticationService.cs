using System;
using FlintSoft.CRM.Application.Common.Interfaces.Authentication;

namespace FlintSoft.CRM.Application.Services;

public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator) : IAuthenticationService
{

    public AuthenticationResult Login(string email, string password)
    {       
        Guid userId = Guid.NewGuid();
        
        var token = jwtTokenGenerator.GenerateToken(userId, "Michael", "Prattinger");

        return new AuthenticationResult(
            userId,
            "Michael",
            "Prattinger",
            token
        );
    }

    public RegistrationResult Register(string firstName, string lastName, string email, string password)
    {
        //Check if user already exists

        //Create user (generate guid)

        return new RegistrationResult(
            Guid.NewGuid(),
            firstName,
            lastName
        );
    }
}
