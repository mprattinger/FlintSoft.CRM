using FlintSoft.CRM.Domain.Entities;

namespace FlintSoft.CRM.Application.Services.Authentication.Queries.Login;

public record AuthenticationResult(
    User user,
    string Token
);
