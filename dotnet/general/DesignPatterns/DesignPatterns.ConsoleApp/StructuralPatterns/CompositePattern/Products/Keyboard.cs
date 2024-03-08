using DesignPatterns.ConsoleApp.StructuralPatterns.CompositePattern.Contract;

namespace DesignPatterns.ConsoleApp.StructuralPatterns.CompositePattern.Products
{
    public class Keyboard : ICalculatePrice
    {
        public string Features { get; set; }
        public decimal Price { get; set; }

        public Keyboard(string features, decimal price)
        {
            Features = features;
            Price = price;
        }

        public decimal CalculatePrice()
        {
            return Price;
        }
    }
}
