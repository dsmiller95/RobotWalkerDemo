using System.Numerics;

namespace RobotWalker;

public class BoundingBox2D
{
    public readonly Vector2 min;
    public readonly Vector2 max;
    
    private BoundingBox2D(Vector2 min, Vector2 max)
    {
        this.min = min;
        this.max = max;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="min">inclusive</param>
    /// <param name="max">exclusive</param>
    /// <returns></returns>
    public static BoundingBox2D FromMinMax(Vector2 min, Vector2 max)
    {
        // TODO: fail when not minmax
        return new BoundingBox2D(min, max);
    }

    /// <summary>
    /// Force this bounds to include the given point
    /// </summary>
    /// <param name="toInclude">inclusive</param>
    /// <returns></returns>
    public BoundingBox2D Expand(Vector2 toInclude)
    {
        var newMin = this.min;
        var newMax = this.max;
        
        newMin.X = Math.Min(min.X, toInclude.X);
        newMin.Y = Math.Min(min.Y, toInclude.Y);
        newMax.X = Math.Max(max.X, toInclude.X + 1);
        newMax.Y = Math.Max(max.Y, toInclude.Y + 1);

        return new BoundingBox2D(newMin, newMax);
    }

    public bool Contains(Vector2 point)
    {
        if(point.X < min.X || point.X >= max.X)
        {
            return false;
        }
        if(point.Y < min.Y || point.Y >= max.Y)
        {
            return false;
        }

        return true;
    }
    
    public override string ToString()
    {
        return $"[{min} - {max})";
    }
}