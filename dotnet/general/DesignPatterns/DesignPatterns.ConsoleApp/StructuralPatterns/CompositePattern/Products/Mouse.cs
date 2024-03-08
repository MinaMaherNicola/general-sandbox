using DesignPatterns.ConsoleApp.StructuralPatterns.CompositePattern.Contract;

namespace DesignPatterns.ConsoleApp.StructuralPatterns.CompositePattern.Products
{
    public class Mouse : ICalculatePrice
    {
        public int DPI { get; set; }
        public decimal Price { get; set; }


        public Mouse(int dPI, decimal price)
        {
            DPI = dPI;
            Price = price;
        }

        public decimal CalculatePrice()
        {
            return Price;
        }
    }
}
