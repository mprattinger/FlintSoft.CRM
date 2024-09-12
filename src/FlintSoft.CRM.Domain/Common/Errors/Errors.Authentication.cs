using System;
using ErrorOr;

namespace FlintSoft.CRM.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication {
        public static Error AuthenticationFailed => Error.Conflict(
            code: "Auth.InvalidCredentials",
            description: "Invalid credentials"
        );
    }
}
