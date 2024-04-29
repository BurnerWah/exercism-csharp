using System;

public static class LogAnalysis {
    public static string SubstringAfter(this string str, string search) {
        var i = str.IndexOf(search) + search.Length;
        return str[i..];
    }

    public static string SubstringBetween(this string str, string left, string right) {
        var leftIndex = str.IndexOf(left) + left.Length;
        var rightIndex = str.IndexOf(right);
        return str[leftIndex..rightIndex];
    }

    public static string Message(this string str) => str.SubstringAfter(": ");

    public static string LogLevel(this string str) => str.SubstringBetween("[", "]");
}
