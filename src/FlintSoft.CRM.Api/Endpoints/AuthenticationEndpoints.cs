using FlintSoft.CRM.Application.Services;
using FlintSoft.CRM.Contracts.Authentication;
using FlintSoft.Endpoints;
using Microsoft.AspNetCore.Http.Connections;


namespace FlintSoft.CRM.Api.Endpoints;

public class AuthenticationEndpoints : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var grp = app.MapGroup("auth")
        .WithOpenApi()
        .WithTags("Authentication");

        grp.MapPost("/register", (RegisterRequest request, IAuthenticationService authenticationService) =>
        {
            var result = authenticationService.Register(request.FirstName,
                                                        request.LastName,
                                                        request.Email,
                                                        request.Password);

            var response = new RegisterResponse(result.user.Id,
                                                result.user.FirstName,
                                                result.user.LastName);

            return Results.Ok(response);
        });

        grp.MapPost("/login", (LoginRequest request, IAuthenticationService authenticationService) =>
        {
            var result = authenticationService.Login(request.Email,
                                                     request.Password);

            var response = new LoginResponse(result.user.Id,
                                             result.user.FirstName,
                                             result.user.LastName,
                                             result.Token);

            return Results.Ok(response);
        });
    }
}
