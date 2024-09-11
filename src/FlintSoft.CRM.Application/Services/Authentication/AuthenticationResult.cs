using System;
using FlintSoft.CRM.Domain.Entities;

namespace FlintSoft.CRM.Application.Services;

public record AuthenticationResult(
    User user,
    string Token
);
