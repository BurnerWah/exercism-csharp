using System;
using System.Globalization;
using System.Runtime.InteropServices;


public enum Location {
    NewYork,
    London,
    Paris
}

public enum AlertLevel {
    Early,
    Standard,
    Late
}

public static class Appointment {
    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();

    private static TimeZoneInfo GetTimeZone(Location location) {
        var windows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        return TimeZoneInfo.FindSystemTimeZoneById(location switch {
            Location.NewYork => windows ? "Eastern Standard Time" : "America/New_York",
            Location.London => windows ? "GMT Standard Time" : "Europe/London",
            Location.Paris => windows ? "W. Europe Standard Time" : "Europe/Paris",
            _ => throw new NotImplementedException(),
        });
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location) {
        var dt = DateTime.Parse(appointmentDateDescription);
        var tzi = GetTimeZone(location);
        // Have to use GetUtcOffset to avoid DST insues
        var offset = tzi.GetUtcOffset(dt);
        return dt - offset;
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) => appointment - alertLevel switch {
        AlertLevel.Early => new TimeSpan(1, 0, 0, 0),
        AlertLevel.Standard => new TimeSpan(1, 45, 0),
        AlertLevel.Late => new TimeSpan(0, 30, 0),
        _ => throw new NotImplementedException(),
    };

    public static bool HasDaylightSavingChanged(DateTime dt, Location location) {
        var tzi = GetTimeZone(location);
        return tzi.IsDaylightSavingTime(dt) != tzi.IsDaylightSavingTime(dt - new TimeSpan(7, 0, 0, 0));

    }

    public static DateTime NormalizeDateTime(string dtStr, Location location) {
        var culture = location switch {
            Location.NewYork => new CultureInfo("en-US"),
            Location.London => new CultureInfo("en-GB"),
            Location.Paris => new CultureInfo("fr-FR"),
            _ => CultureInfo.InvariantCulture,
        };
        try {
            return DateTime.Parse(dtStr, culture);
        }
        catch (FormatException) {
            return new DateTime(1, 1, 1);
        }
    }
}
