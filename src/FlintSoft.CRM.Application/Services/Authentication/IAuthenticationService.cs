namespace FlintSoft.CRM.Application.Services;

public interface IAuthenticationService
{
    AuthenticationResult Login(string email, string password);
    RegistrationResult Register(string firstName, string lastName, string email, string password);
}
