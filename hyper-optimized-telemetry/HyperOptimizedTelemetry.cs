using System;

public static class TelemetryBuffer {
    public static byte[] ToBuffer(long reading) => reading switch {
        > UInt32.MaxValue => [0xf8, .. BitConverter.GetBytes(reading)],
        > Int32.MaxValue => [0x4, .. BitConverter.GetBytes(reading)],
        > UInt16.MaxValue => [0xfc, .. BitConverter.GetBytes(reading)],
        >= 0 => [0x2, .. BitConverter.GetBytes(reading)],
        >= Int16.MinValue => [0xfe, .. BitConverter.GetBytes((short)reading), 0x0, 0x0, 0x0, 0x0, 0x0, 0x0],
        >= Int32.MinValue => [0xfc, .. BitConverter.GetBytes((int)reading), 0x0, 0x0, 0x0, 0x0],
        >= Int64.MinValue => [0xf8, .. BitConverter.GetBytes(reading)],
    };

    public static long FromBuffer(byte[] buffer) => buffer[0] switch {
        0xf8 => BitConverter.ToInt64(buffer.AsSpan()[1..]),
        0x4 => BitConverter.ToUInt32(buffer.AsSpan()[1..]),
        0xfc => BitConverter.ToInt32(buffer.AsSpan()[1..]),
        0x2 => BitConverter.ToUInt16(buffer.AsSpan()[1..]),
        0xfe => BitConverter.ToInt16(buffer.AsSpan()[1..]),
        _ => 0,
    };
}
