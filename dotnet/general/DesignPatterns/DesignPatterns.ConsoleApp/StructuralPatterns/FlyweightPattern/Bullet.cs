using DesignPatterns.ConsoleApp.StructuralPatterns.FlyweightPattern.FlyweightObjects;

namespace DesignPatterns.ConsoleApp.StructuralPatterns.FlyweightPattern
{
    public class Bullet
    {
        public Bullet(Color color, int x, int y, int z)
        {
            Color = color;
            X = x;
            Y = y;
            Z = z;
        }
        public Color Color { get; set; } = null!;
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
}
