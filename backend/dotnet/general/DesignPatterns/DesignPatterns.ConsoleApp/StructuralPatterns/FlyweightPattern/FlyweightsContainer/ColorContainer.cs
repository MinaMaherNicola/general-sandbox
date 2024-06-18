using DesignPatterns.ConsoleApp.StructuralPatterns.FlyweightPattern.FlyweightObjects;

namespace DesignPatterns.ConsoleApp.StructuralPatterns.FlyweightPattern.FlyweightsContainer
{
    public class ColorContainer
    {
        private static ColorContainer? singletonInstance;
        private readonly Dictionary<string, Color> colorsCache;
        private static readonly object singletonLock = new object();

        private ColorContainer()
        {
            colorsCache = new Dictionary<string, Color>();
        }

        public Color GetColor(string colorName, string? hexIfNotFound = null)
        {
            if (colorsCache.ContainsKey(colorName))
            {
                return colorsCache[colorName];
            }
            if (string.IsNullOrWhiteSpace(hexIfNotFound))
            {
                throw new ArgumentNullException(nameof(hexIfNotFound));
            }
            var newColor = new Color(colorName, hexIfNotFound);
            colorsCache[colorName] = newColor;
            return newColor;
        }

        public static ColorContainer GetInstance
        {
            get
            {
                lock (singletonLock)
                {
                    if (singletonInstance == null) return new ColorContainer();
                    return new ColorContainer();
                }
            }
        }
    }
}
