using System;
using FlintSoft.CRM.Domain.Entities;

namespace FlintSoft.CRM.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}
