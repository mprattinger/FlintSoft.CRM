using System;
using FlintSoft.CRM.Application.Common.Interfaces.Authentication;
using FlintSoft.CRM.Application.Common.Interfaces.Persistence;
using FlintSoft.CRM.Domain.Entities;

namespace FlintSoft.CRM.Application.Services;

public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator,
                                   IUserRepository userRepository) : IAuthenticationService
{

    public AuthenticationResult Login(string email, string password)
    {
        if (userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("Authentication unsuccessfull");
        }

        if (user.Password != password)
        {
            throw new Exception("Authentication unsuccessfull");
        }

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }

    public RegistrationResult Register(string firstName, string lastName, string email, string password)
    {
        //Check if user already exists
        if (userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists");
        }

        //Create user (generate guid)
        var user = new User
        {
            FirstName = firstName,
            Email = email,
            LastName = lastName,
            Password = password
        };

        userRepository.Add(user);

        return new RegistrationResult(
            user
        );
    }
}
