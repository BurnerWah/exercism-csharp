using System;

public enum Direction {
    North,
    East,
    South,
    West
}

public class RobotSimulator(Direction direction, int x, int y) {
    private (Direction Direction, int X, int Y) position = (direction, x, y);

    public Direction Direction => position.Direction;
    public int X => position.X;
    public int Y => position.Y;

    public void Move(string instructions) {
        foreach (var command in instructions) {
            position = (Direction, command) switch {
                (Direction.North, 'A') => (Direction, X, Y + 1),
                (Direction.North, 'R') => (Direction.East, X, Y),
                (Direction.North, 'L') => (Direction.West, X, Y),
                (Direction.East, 'A') => (Direction, X + 1, Y),
                (Direction.East, 'R') => (Direction.South, X, Y),
                (Direction.East, 'L') => (Direction.North, X, Y),
                (Direction.South, 'A') => (Direction, X, Y - 1),
                (Direction.South, 'R') => (Direction.West, X, Y),
                (Direction.South, 'L') => (Direction.East, X, Y),
                (Direction.West, 'A') => (Direction, X - 1, Y),
                (Direction.West, 'R') => (Direction.North, X, Y),
                (Direction.West, 'L') => (Direction.South, X, Y),
                _ => position,
            };
        }
    }
}
