using FlintSoft.CRM.Application.Services;
using FlintSoft.CRM.Contracts.Authentication;
using FlintSoft.Endpoints;


namespace FlintSoft.CRM.Api.Endpoints;

public class AuthenticationEndpoints : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var grp = app.MapGroup("auth")
        .WithOpenApi()
        .WithTags("Authentication");
        
        grp.MapPost("/register", (RegisterRequest request, IAuthenticationService authenticationService) => {
            var result = authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

            return Results.Ok(result);
        });

        grp.MapPost("/login", (LoginRequest request, IAuthenticationService authenticationService) => {
            var result = authenticationService.Login(request.Email, request.Password);

            return Results.Ok(result);
        });
    }
}
