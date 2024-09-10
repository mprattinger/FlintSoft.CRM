using System;
using FlintSoft.CRM.Application.Common.Interfaces.Services;

namespace FlintSoft.CRM.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
