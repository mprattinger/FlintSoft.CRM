using FlintSoft.CRM.Application.Services;
using FlintSoft.CRM.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace FlintSoft.CRM.Api.Controllers;

[Route("auth")]
[ApiController]
public class AuthController(IAuthenticationService authenticationService) : ControllerBase
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
            err => Problem(statusCode: (int)err.StatusCode, title: err.ErrorMessage)
        );
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var result = authenticationService.Login(request.Email,
                                                        request.Password);

        var response = new LoginResponse(result.user.Id,
                                            result.user.FirstName,
                                            result.user.LastName,
                                            result.Token);

        return Ok(response);
    }

    private static RegisterResponse MapResult(RegistrationResult regResult)
    {
        return new RegisterResponse(regResult.user.Id,
                                                        regResult.user.FirstName,
                                                        regResult.user.LastName);
    }
}