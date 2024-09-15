using System;
using FlintSoft.CRM.Domain.Entities;

namespace FlintSoft.CRM.Application.Services.Authentication.Commands.Register;

public record RegistrationResult(
    User user
);
