using FlintSoft.CRM.Application.Services;
using FlintSoft.CRM.Contracts.Authentication;
using FlintSoft.CRM.Domain.Common.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlintSoft.CRM.Api.Controllers;

[Route("auth")]
public class AuthController(IAuthenticationService authenticationService) : ApiController
{
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var result = authenticationService.Register(request.FirstName,
                                                    request.LastName,
                                                    request.Email,
                                                    request.Password);
        return result.Match(
            r => Ok(MapResult(r)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var result = authenticationService.Login(request.Email,
                                                        request.Password);

        if(result.IsError && result.FirstError == Errors.Authentication.AuthenticationFailed){
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