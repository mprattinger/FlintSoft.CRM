using FlintSoft.CRM.Domain.Entities;

namespace FlintSoft.CRM.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
