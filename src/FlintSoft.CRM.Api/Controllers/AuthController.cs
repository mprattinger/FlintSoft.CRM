using FlintSoft.CRM.Application.Services.Authentication.Commands.Register;
using FlintSoft.CRM.Application.Services.Authentication.Queries.Login;
using FlintSoft.CRM.Contracts.Authentication;
using FlintSoft.CRM.Domain.Common.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlintSoft.CRM.Api.Controllers;

[Route("auth")]
public class AuthController(ISender mediator) : ApiController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName,
                                                    request.LastName,
                                                    request.Email,
                                                    request.Password);

        var result = await mediator.Send(command);

        return result.Match(
            r => Ok(MapResult(r)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);

        var result = await mediator.Send(query);

        if (result.IsError && result.FirstError == Errors.Authentication.AuthenticationFailed)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: result.FirstError.Description);
        }

        return result.Match(
            r => Ok(MapResult(r)),
            errors => Problem(errors)
        );
    }

    private static RegisterResponse MapResult(RegistrationResult regResult)
    {
        return new RegisterResponse(regResult.user.Id,
                                                        regResult.user.FirstName,
                                                        regResult.user.LastName);
    }

    private static LoginResponse MapResult(AuthenticationResult result)
    {
        return new LoginResponse(result.user.Id,
                                            result.user.FirstName,
                                            result.user.LastName,
                                            result.Token);
    }
}