using System.Numerics;
using static RobotWalker.RobotWalkerCommand;

namespace RobotWalker;

public class RobotWalkerTest
{
    [Fact]
    public void WhenRunningDemoSequence_RunsSequence()
    {
        var commands = new RobotWalkerCommand[]
        {
            MoveForward,
            TurnLeft,
            MoveForward,
            MoveForward,
            TurnLeft,
            MoveForward,
            TurnRight,
            TurnRight,
            TurnRight,
            MoveForward
        };
        var walker = new RobotWalkerObject();
        foreach (var command in commands)
        {
            walker = walker.ExecuteCommand(command);
        }
        
        Assert.Equal(new Vector2(-1, 0), walker.Position.Point);
        Assert.Equal(Direction.East, walker.Position.Direction);
    }
    
    [Fact]
    public void WhenRobotIsInBoundedWorld_WalksUpToBounds()
    {
        var world = new RobotWorld
        {
            Walker = new RobotWalkerObject(),
            Bounds = BoundingBox2D.FromMinMax(new Vector2(-2, -2), new Vector2(2, 2))
        };
        
        ExecutionStatus status;
        (world, status) = world.ExecuteCommand(MoveForward);
        Assert.Equal(ExecutionStatus.Success, status);
        
        (world, status) = world.ExecuteCommand(MoveForward);
        Assert.Equal(ExecutionStatus.Blocked, status);
    }
}