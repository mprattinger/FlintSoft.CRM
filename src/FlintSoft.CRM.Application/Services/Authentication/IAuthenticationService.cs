using ErrorOr;

namespace FlintSoft.CRM.Application.Services;

public interface IAuthenticationService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
    ErrorOr<RegistrationResult> Register(string firstName, string lastName, string email, string password);
}
