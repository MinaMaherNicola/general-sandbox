using DesignPatterns.ConsoleApp.CreationalPatterns.BuilderPattern.Product.SubProducts;

namespace DesignPatterns.ConsoleApp.CreationalPatterns.BuilderPattern.Product
{
    public class Invoice
    {
        public List<Item> Items { get; set; }
        public List<Discount> Discounts { get; set; }
    }
}
