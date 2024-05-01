using System;
using System.Text;

public static class Identifier {
    public static string Clean(string identifier) {
        var sb = new StringBuilder();
        for (int i = 0; i < identifier.Length; i++) {
            if (Char.IsWhiteSpace(identifier[i])) {
                sb.Append('_');
            } else if (Char.IsControl(identifier[i])) {
                sb.Append("CTRL");
            } else if (i > 0 && identifier[i - 1] == '-') {
                sb.Append(Char.ToUpper(identifier[i]));
            } else if (Char.IsLetter(identifier[i]) && !Char.IsBetween(identifier[i], 'α', 'ω')) {
                sb.Append(identifier[i]);
            }
        }
        return sb.ToString();
    }
}
