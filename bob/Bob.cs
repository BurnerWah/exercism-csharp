using System;
using System.Text.RegularExpressions;

public static class Bob {
    public static string Response(string statement) {
        var re = new Regex("[a-zA-Z]");
        if (statement == statement.ToUpper() && re.IsMatch(statement)) {
            return statement.Trim().EndsWith('?') ? "Calm down, I know what I'm doing!" : "Whoa, chill out!";
        } else if (statement.Trim().EndsWith('?')) {
            return "Sure.";
        } else if (statement.Trim().Length == 0) {
            return "Fine. Be that way!";
        } else {
            return "Whatever.";
        }
    }
}
