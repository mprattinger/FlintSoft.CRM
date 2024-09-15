using ErrorOr;
using MediatR;

namespace FlintSoft.CRM.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) :
IRequest<ErrorOr<LoginResult>>;
