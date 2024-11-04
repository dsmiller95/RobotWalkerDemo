namespace RobotWalker;

public class UnitTest1
{
    [Fact]
    public void WhenFacingNorth_TurnsRight_FacesEast()
    {
        var dir = Direction.North;
        dir = dir.TurnRight();
        
        Assert.Equal(Direction.East, dir);
    }
    [Fact]
    public void WhenFacingNorth_TurnsLeft_FacesWest()
    {
        var dir = Direction.North;
        dir = dir.TurnLeft();
        
        Assert.Equal(Direction.West, dir);
    }
}