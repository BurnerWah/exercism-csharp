using System;
using System.Collections.Generic;

public class FacialFeatures(string eyeColor, decimal philtrumWidth) : IEquatable<FacialFeatures> {
    public string EyeColor { get; } = eyeColor;
    public decimal PhiltrumWidth { get; } = philtrumWidth;

    public override bool Equals(object obj) => this.Equals(obj as FacialFeatures);
    public bool Equals(FacialFeatures other) {
        if (other is null) {
            return false;
        }
        if (Object.ReferenceEquals(this, other)) {
            return true;
        }
        if (this.GetType() != other.GetType()) {
            return false;
        }
        return EyeColor == other.EyeColor && PhiltrumWidth == other.PhiltrumWidth;
    }

    public static bool operator ==(FacialFeatures lhs, FacialFeatures rhs) => (lhs, rhs) switch {
        (null, null) => true,
        (null, _) => false,
        (_, null) => false,
        (_, _) => lhs.Equals(rhs),
    };
    public static bool operator !=(FacialFeatures lhs, FacialFeatures rhs) => !(lhs == rhs);

    public override int GetHashCode() => (EyeColor, PhiltrumWidth).GetHashCode();

}

public class Identity(string email, FacialFeatures facialFeatures) : IEquatable<Identity> {
    public string Email { get; } = email;
    public FacialFeatures FacialFeatures { get; } = facialFeatures;

    public bool Equals(Identity other) {
        if (other is null) {
            return false;
        }
        if (Object.ReferenceEquals(this, other)) {
            return true;
        }
        if (this.GetType() != other.GetType()) {
            return false;
        }
        return Email == other.Email && FacialFeatures == other.FacialFeatures;
    }
    public override bool Equals(object obj) => this.Equals(obj as Identity);

    public static bool operator ==(Identity lhs, Identity rhs) => (lhs, rhs) switch {
        (null, null) => true,
        (null, _) => false,
        (_, null) => false,
        (_, _) => lhs.Equals(rhs),
    };
    public static bool operator !=(Identity lhs, Identity rhs) => !(lhs == rhs);


    public override int GetHashCode() => (Email, FacialFeatures).GetHashCode();
}

public class Authenticator {
    private HashSet<Identity> identities = new HashSet<Identity>();

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA == faceB;

    public bool IsAdmin(Identity identity) => identity == new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));

    public bool Register(Identity identity) => identities.Add(identity);

    public bool IsRegistered(Identity identity) => identities.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) => Object.ReferenceEquals(identityA, identityB);
}
