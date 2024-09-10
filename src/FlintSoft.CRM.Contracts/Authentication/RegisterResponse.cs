namespace FlintSoft.CRM.Contracts.Authentication;

public record RegisterResponse(
    Guid Id,
    string FirstName,
    string LastName);
