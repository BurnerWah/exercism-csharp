using System.Collections.Generic;

public class Authenticator(Identity admin) {
    private static class EyeColor {
        public const string Blue = "blue";
        public const string Green = "green";
        public const string Brown = "brown";
        public const string Hazel = "hazel";
        public const string Grey = "grey";
    }

    public Identity Admin { get; set; } = admin;

    private readonly IDictionary<string, Identity> developers = new Dictionary<string, Identity> {
        ["Bertrand"] = new Identity {
            Email = "bert@ex.ism",
            EyeColor = EyeColor.Blue,
        },
        ["Anders"] = new Identity {
            Email = "anders@ex.ism",
            EyeColor = EyeColor.Brown,
        }
    };

    public IDictionary<string, Identity> GetDevelopers() => developers.AsReadOnly();
}

public struct Identity {
    public string Email { get; set; }

    public string EyeColor { get; set; }
}
