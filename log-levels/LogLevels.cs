using System;

static class LogLine {
    public static string Message(string logLine) {
        if (logLine.StartsWith("[INFO]")) {
            return logLine[8..].Trim();
        } else if (logLine.StartsWith("[WARNING]")) {
            return logLine[11..].Trim();
        } else if (logLine.StartsWith("[ERROR]")) {
            return logLine[9..].Trim();
        }
        return logLine.Trim();
    }

    public static string LogLevel(string logLine) {
        if (logLine.StartsWith("[INFO]")) {
            return "info";
        } else if (logLine.StartsWith("[WARNING]")) {
            return "warning";
        } else if (logLine.StartsWith("[ERROR]")) {
            return "error";
        }
        return "invalid";
    }

    public static string Reformat(string logLine) => $"{LogLine.Message(logLine)} ({LogLine.LogLevel(logLine)})";
}
