using System.Numerics;

namespace RobotWalker;

public class BoundsTest
{

    private Vector2 V2(float x, float y) => new(x, y);
    [Fact]
    public void WhenExpandingBounds_ExpandsBounds()
    {
        var bounds = BoundingBox2D.FromMinMax(V2(-1, -1), V2(1, 1));
        
        Assert.False(bounds.Contains(V2(1, 1)));
        bounds = bounds.Expand(V2(1, 1));
        Assert.True(bounds.Contains(V2(1, 1)));
        
        Assert.False(bounds.Contains(V2(-2, -2)));
        bounds = bounds.Expand(V2(-2, -2));
        Assert.True(bounds.Contains(V2(-2, -2)));
        
        Assert.False(bounds.Contains(V2(5, 8)));
        bounds = bounds.Expand(V2(10, 10));
        Assert.True(bounds.Contains(V2(5, 8)));
    }
}