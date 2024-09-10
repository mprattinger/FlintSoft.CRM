namespace FlintSoft.CRM.Contracts.Authentication;

public record LoginResponse(
    Guid id,
    string FirstName,
    string LastName,
    string Token);