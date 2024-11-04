namespace RobotWalker;

public record RobotWalkerObject
{
    public Position Position { get; init; }
    
    public RobotWalkerObject ExecuteCommand(RobotWalkerCommand command)
    {
        var newPos = Position;
        // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
        switch (command)
        {
            case RobotWalkerCommand.TurnLeft:
                newPos.Direction = newPos.Direction.TurnLeft();
                break;
            case RobotWalkerCommand.TurnRight:
                newPos.Direction = newPos.Direction.TurnRight();
                break;
            case RobotWalkerCommand.MoveForward:
                newPos.Point = newPos.Point + newPos.Direction.ToFacing();
                break;
            default: throw new ArgumentException();
        }
        return this with { Position = newPos };
    }

    public override string ToString()
    {
        return $"Robot at {Position.Point} facing {Position.Direction}";
    }
}

public enum RobotWalkerCommand
{
    TurnLeft,
    TurnRight,
    MoveForward
}