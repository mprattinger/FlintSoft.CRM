using System;
using FlintSoft.CRM.Domain.Entities;

namespace FlintSoft.CRM.Application.Authentication.Commands.Register;

public record RegistrationResult(
    User user
);
