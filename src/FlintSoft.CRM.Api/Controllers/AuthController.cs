using FlintSoft.CRM.Application.Authentication.Commands.Register;
using FlintSoft.CRM.Application.Authentication.Queries.Login;
using FlintSoft.CRM.Contracts.Authentication;
using FlintSoft.CRM.Domain.Common.Errors;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlintSoft.CRM.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthController(ISender mediator, IMapper mapper) : ApiController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = mapper.Map<RegisterCommand>(request);

        var result = await mediator.Send(command);

        return result.Match(
            r => Ok(mapper.Map<RegisterResponse>(r)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = mapper.Map<LoginQuery>(request);

        var result = await mediator.Send(query);

        if (result.IsError && result.FirstError == Errors.Authentication.AuthenticationFailed)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: result.FirstError.Description);
        }

        return result.Match(
            r => Ok(mapper.Map<LoginResponse>(r)),
            errors => Problem(errors)
        );
    }
}