using DesignPatterns.ConsoleApp.StructuralPatterns.CompositePattern.Contract;

namespace DesignPatterns.ConsoleApp.StructuralPatterns.CompositePattern
{
    public class Invoice : ICalculatePrice
    {
        public decimal Price { get; set; }
        public List<ICalculatePrice> Items { get; set; }

        public Invoice(List<ICalculatePrice> items)
        {
            Items = items;
            Price = Items.Sum(i => i.CalculatePrice());
        }

        public decimal CalculatePrice()
        {
            return Price;
        }
    }
}
