using System;

static class Badge {
    public static string Print(int? id, string name, string? department) {
        if (id == null) {
            return $"{name} - {(department ?? "OWNER").ToUpper()}";
        } else {
            return $"[{id}] - {name} - {(department ?? "OWNER").ToUpper()}";
        }
    }
}
