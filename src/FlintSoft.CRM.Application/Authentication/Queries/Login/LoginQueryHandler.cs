using System;
using ErrorOr;
using FlintSoft.CRM.Application.Common.Interfaces.Persistence;
using FlintSoft.CRM.Domain.Entities;
using FlintSoft.CRM.Domain.Common.Errors;
using MediatR;
using FlintSoft.CRM.Application.Common.Interfaces.Authentication;

namespace FlintSoft.CRM.Application.Authentication.Queries.Login;

public class LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator) : IRequestHandler<LoginQuery, ErrorOr<LoginResult>>
{
    public async Task<ErrorOr<LoginResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.AuthenticationFailed;
        }

        if (user.Password != query.Password)
        {
            return Errors.Authentication.AuthenticationFailed;
        }

        var token = jwtTokenGenerator.GenerateToken(user);

        return new LoginResult(
            user,
            token
        );
    }
}
