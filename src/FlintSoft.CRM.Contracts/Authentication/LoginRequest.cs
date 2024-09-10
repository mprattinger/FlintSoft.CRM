namespace FlintSoft.CRM.Contracts.Authentication;

public record LoginRequest(
    string Email,
    string Password);
