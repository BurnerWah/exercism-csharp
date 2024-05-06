using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

public struct Coord(ushort x, ushort y) {
    public ushort X { get; } = x;
    public ushort Y { get; } = y;

    public readonly Vector2 Vec => new Vector2(X, Y);
}

public struct Plot(Coord coord1, Coord coord2, Coord coord3, Coord coord4) {
    public Coord Coord1 { get; } = coord1;
    public Coord Coord2 { get; } = coord2;
    public Coord Coord3 { get; } = coord3;
    public Coord Coord4 { get; } = coord4;

    public readonly double LongestSideLength => new List<float> {
        Vector2.Distance(Coord1.Vec, Coord2.Vec),
        Vector2.Distance(Coord2.Vec, Coord3.Vec),
        Vector2.Distance(Coord3.Vec, Coord4.Vec),
        Vector2.Distance(Coord4.Vec, Coord1.Vec),
    }.Order().Last();
}


public class ClaimsHandler {
    private readonly HashSet<Plot> claimed = new HashSet<Plot>();
    private Plot last;

    public void StakeClaim(Plot plot) {
        claimed.Add(plot);
        last = plot;
    }

    public bool IsClaimStaked(Plot plot) => claimed.Contains(plot);

    public bool IsLastClaim(Plot plot) => last.Equals(plot);

    public Plot GetClaimWithLongestSide() => claimed.OrderBy(plot => plot.LongestSideLength).Last();
}
