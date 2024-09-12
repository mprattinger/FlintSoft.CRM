using FlintSoft.CRM.Application.Common.Errors;
using OneOf;

namespace FlintSoft.CRM.Application.Services;

public interface IAuthenticationService
{
    AuthenticationResult Login(string email, string password);
    OneOf<RegistrationResult, IError> Register(string firstName, string lastName, string email, string password);
}
