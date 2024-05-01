using System;

enum AccountType {
    Guest,
    User,
    Moderator,
}

[Flags]
enum Permission {
    None,
    Read = 1,
    Write = 2,
    Delete = 4,
    All = Permission.Read | Permission.Write | Permission.Delete,
}

static class Permissions {
    public static Permission Default(AccountType accountType) => accountType switch {
        AccountType.Guest => Permission.Read,
        AccountType.User => Permission.Read | Permission.Write,
        AccountType.Moderator => Permission.All,
        _ => Permission.None,
    };

    public static Permission Grant(Permission current, Permission grant) => current | grant;

    // AND Complement is equivalent to NAND
    public static Permission Revoke(Permission current, Permission revoke) => current & ~revoke;

    public static bool Check(Permission current, Permission check) => current.HasFlag(check);
}
