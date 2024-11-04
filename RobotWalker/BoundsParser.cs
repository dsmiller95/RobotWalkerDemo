using System.Diagnostics;
using System.Numerics;
using System.Text.Json;

namespace RobotWalker;

public class BoundsParser
{
    public BoundingBox2D ParseFromJson(string json)
    {
        var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        var model = System.Text.Json.JsonSerializer.Deserialize<BoundsModel>(json, options);

        Debug.Assert(model != null, nameof(model) + " != null");
        
        var start = model.Extents[0].ToVector2();
        var bounds = BoundingBox2D.FromMinMax(start, start);
        foreach (var extent in model.Extents.Skip(1))
        {
            bounds = bounds.Expand(extent.ToVector2());
        }

        return bounds;
    }

    private class BoundsModel
    {
        public Vector2Serializable[] Extents { get; set; }
    }

    private class Vector2Serializable
    {
        public int X { get; set; }
        public int Y { get; set; }
        
        public Vector2 ToVector2() => new(X, Y);
    }
}