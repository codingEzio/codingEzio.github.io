public class Point
{
    public int X { get; set; }
    public int Y { get; set; }
}

public class Shape
{
    public Point Center { get; set; }
    public List<Point> Vertices { get; set; }

    public Shape ShallowCopy()
    {
        return (Shape)this.MemberwiseClone();
    }

    public Shape DeepCopy()
    {
        Shape copy = (Shape)this.MemberwiseClone();
        copy.Center = new Point { X = this.Center.X, Y = this.Center.Y };
        copy.Vertices = this.Vertices
          .Select(v => new Point { X = v.X, Y = v.Y })
          .ToList();
        return copy;
    }
}

// Usage
var original = new Shape
{
    Center = new Point { X = 0, Y = 0 },
    Vertices = new List<Point> { new Point { X = 1, Y = 1 } }
};

var shallowCopy = original.ShallowCopy();
var deepCopy = original.DeepCopy();
var deepCopyViaClone = original.Clone();

// Modify the original
original.Center.X = 5;
original.Vertices[0].X = 10;

Console.WriteLine($"Original - Center: ({original.Center.X}, {original.Center.Y})");
Console.WriteLine($"Original - Vertex: ({original.Vertices[0].X}, {original.Vertices[0].Y})");

Console.WriteLine($"Shallow - Center: ({shallowCopy.Center.X}, {shallowCopy.Center.Y})");
Console.WriteLine($"Shallow - Vertex: ({shallowCopy.Vertices[0].X}, {shallowCopy.Vertices[0].Y})");

Console.WriteLine($"Deep - Center: ({deepCopy.Center.X}, {deepCopy.Center.Y})");
Console.WriteLine($"Deep - Vertex: ({deepCopy.Vertices[0].X}, {deepCopy.Vertices[0].Y})");
