using System;

public static class TelemetryBuffer {
    public static byte[] ToBuffer(long reading) => reading switch {
        >= 4_294_967_296 => [0xf8, .. BitConverter.GetBytes(reading)],
        >= 2_147_483_648 => [0x4, .. BitConverter.GetBytes(reading)],
        >= 65_536 => [0xfc, .. BitConverter.GetBytes(reading)],
        >= 0 => [0x2, .. BitConverter.GetBytes(reading)],
        >= -32_768 => [0xfe, .. BitConverter.GetBytes((short)reading), 0x0, 0x0, 0x0, 0x0, 0x0, 0x0],
        >= -2_147_483_648 => [0xfc, .. BitConverter.GetBytes((int)reading), 0x0, 0x0, 0x0, 0x0],
        >= -9_223_372_036_854_775_808 => [0xf8, .. BitConverter.GetBytes(reading)],
        // _ => []
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
