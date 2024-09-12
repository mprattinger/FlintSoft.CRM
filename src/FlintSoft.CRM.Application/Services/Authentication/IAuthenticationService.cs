using FlintSoft.CRM.Application.Common.Errors;
using FluentResults;

namespace FlintSoft.CRM.Application.Services;

public interface IAuthenticationService
{
    AuthenticationResult Login(string email, string password);
    Result<RegistrationResult> Register(string firstName, string lastName, string email, string password);
}
