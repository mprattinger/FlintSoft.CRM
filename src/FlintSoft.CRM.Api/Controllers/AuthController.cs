using FlintSoft.CRM.Api.Filters;
using FlintSoft.CRM.Application.Services;
using FlintSoft.CRM.Contracts.Authentication;
using Microsoft.AspNetCore.Http;
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

        var response = new RegisterResponse(result.user.Id,
                                            result.user.FirstName,
                                            result.user.LastName);

        return Ok(response);
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
}