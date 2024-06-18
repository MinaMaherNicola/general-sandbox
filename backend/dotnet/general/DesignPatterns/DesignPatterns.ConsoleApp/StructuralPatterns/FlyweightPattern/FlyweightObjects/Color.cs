namespace DesignPatterns.ConsoleApp.StructuralPatterns.FlyweightPattern.FlyweightObjects
{
    public class Color
    {
        public Color(string name, string hexValue)
        {
            Name = name;
            HexValue = hexValue;
        }

        public string Name { get; set; } = null!;
        public string HexValue { get; set; } = null!;
    }
}
