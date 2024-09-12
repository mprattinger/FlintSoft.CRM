using System;
using ErrorOr;

namespace FlintSoft.CRM.Domain.Common.Errors;

public static partial class Errors
{
    public static class User {
        public static Error DuplicateEmail => Error.Conflict(code: "User.Duplicate",
                                                             description: "User already exists");
    }
}
