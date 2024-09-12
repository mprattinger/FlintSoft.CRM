using ErrorOr;
using FlintSoft.CRM.Application.Common.Interfaces.Authentication;
using FlintSoft.CRM.Application.Common.Interfaces.Persistence;
using FlintSoft.CRM.Domain.Common.Errors;
using FlintSoft.CRM.Domain.Entities;

namespace FlintSoft.CRM.Application.Services;

public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator,
                                   IUserRepository userRepository) : IAuthenticationService
{

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        if (userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.AuthenticationFailed;
        }

        if (user.Password != password)
        {
            return Errors.Authentication.AuthenticationFailed;
        }

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }

    public ErrorOr<RegistrationResult> Register(string firstName, string lastName, string email, string password)
    {
        //Check if user already exists
        if (userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
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
