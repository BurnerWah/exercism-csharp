using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class LogParser {
    public bool IsValidLine(string text) {
        var re = new Regex(@"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]");
        return re.IsMatch(text);
    }

    public string[] SplitLogLine(string text) {
        var re = new Regex(@"<[\^*=\-]*>");
        return re.Split(text);
    }

    public int CountQuotedPasswords(string lines) {
        var re = new Regex("\".*password.*\"", RegexOptions.IgnoreCase | RegexOptions.Multiline);
        return re.Count(lines);
    }

    public string RemoveEndOfLineText(string line) {
        var re = new Regex(@"end-of-line\d+");
        return re.Replace(line, "");
    }

    public string[] ListLinesWithPasswords(string[] lines) {
        var re = new Regex(@"^(.*)(password.*?)( .*$|$)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        var results = new List<string>();
        foreach (var line in lines) {
            results.Add(re.Replace(line, ReplacePassword));
        }
        return [.. results];
    }

    private static string ReplacePassword(Match m) => m.Groups[2].Value.Equals("password", StringComparison.CurrentCultureIgnoreCase) ? $"--------: {m.Groups[0]}" : $"{m.Groups[2]}: {m.Groups[0]}";
}
