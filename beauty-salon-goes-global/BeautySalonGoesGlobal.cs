using System;
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

    public static DateTime Schedule(string appointmentDateDescription, Location location) {
        // I'm kinda stuck on anything that involves specific timezones
        // return DateTime.Parse(appointmentDateDescription, )
        var x = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        var y = TimeZoneInfo.FindSystemTimeZoneById(location switch {
            Location.NewYork => x ? "Eastern Standard Time" : "America/New_York",
            Location.London => x ? "GMT Standard Time" : "Europe/London",
            Location.Paris => x ? "W. Europe Standard Time" : "Europe/Paris",
            _ => throw new NotImplementedException(),
        });
        var z = DateTime.Parse(appointmentDateDescription);
        return z;
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) => appointment - alertLevel switch {
        AlertLevel.Early => new TimeSpan(1, 0, 0, 0),
        AlertLevel.Standard => new TimeSpan(1, 45, 0),
        AlertLevel.Late => new TimeSpan(0, 30, 0),
        _ => throw new NotImplementedException(),
    };

    public static bool HasDaylightSavingChanged(DateTime dt, Location location) {
        var x = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        var y = TimeZoneInfo.FindSystemTimeZoneById(location switch {
            Location.NewYork => x ? "Eastern Standard Time" : "America/New_York",
            Location.London => x ? "GMT Standard Time" : "Europe/London",
            Location.Paris => x ? "W. Europe Standard Time" : "Europe/Paris",
            _ => throw new NotImplementedException(),
        });
        return y.IsDaylightSavingTime(dt.ToUniversalTime()) == y.IsDaylightSavingTime(dt.ToUniversalTime() - new TimeSpan(7, 0, 0, 0));
        // return dt.IsDaylightSavingTime() == dt.AddDays(-7).IsDaylightSavingTime();
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location) {
        throw new NotImplementedException("Please implement the (static) Appointment.NormalizeDateTime() method");
    }
}
