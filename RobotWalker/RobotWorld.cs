namespace RobotWalker;

public record RobotWorld
{
    public RobotWalkerObject Walker { get; init; }
    public BoundingBox2D Bounds { get; init; }
    
    public (RobotWorld, ExecutionStatus) ExecuteCommand(RobotWalkerCommand command)
    {
        var newWalker = Walker.ExecuteCommand(command);
        if (Bounds.Contains(newWalker.Position.Point))
        {
            return (
                this with { Walker = newWalker },
                ExecutionStatus.Success
                    );
        }
        return (this, ExecutionStatus.Blocked);
    }
}

public enum ExecutionStatus
{
    Success,
    Blocked
}