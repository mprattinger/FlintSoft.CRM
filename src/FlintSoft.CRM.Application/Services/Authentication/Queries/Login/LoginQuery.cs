using ErrorOr;
using MediatR;

namespace FlintSoft.CRM.Application.Services.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) :
IRequest<ErrorOr<AuthenticationResult>>;
