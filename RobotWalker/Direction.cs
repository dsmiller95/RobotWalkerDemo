using System.Numerics;

public enum Direction
{
    North = 0,
    East = 1,
    South = 2,
    West = 3
}


public static class DirectionExtensions
{
    public static Direction TurnLeft(this Direction direction)
    {
        return (Direction)(((int)direction + 3) % 4);
    }

    public static Direction TurnRight(this Direction direction)
    {
        return (Direction)(((int)direction + 1) % 4);
    }

    public static Vector2 ToFacing(this Direction direction)
    {
        return direction switch {
            Direction.North => new Vector2(0, 1),
            Direction.East => new Vector2(1, 0),
            Direction.South => new Vector2(0, -1),
            Direction.West => new Vector2(-1, 0),
            _ => Vector2.Zero
        };
    }
}