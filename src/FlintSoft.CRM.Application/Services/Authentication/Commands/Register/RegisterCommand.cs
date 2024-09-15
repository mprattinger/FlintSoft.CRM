using System;
using ErrorOr;
using MediatR;

namespace FlintSoft.CRM.Application.Services.Authentication.Commands.Register;

public record RegisterCommand(string FirstName, string LastName, string Email, string Password)
 : IRequest<ErrorOr<RegistrationResult>>;