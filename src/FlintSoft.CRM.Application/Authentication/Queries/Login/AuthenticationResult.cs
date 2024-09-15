using FlintSoft.CRM.Domain.Entities;

namespace FlintSoft.CRM.Application.Authentication.Queries.Login;

public record LoginResult(
    User user,
    string Token
);
