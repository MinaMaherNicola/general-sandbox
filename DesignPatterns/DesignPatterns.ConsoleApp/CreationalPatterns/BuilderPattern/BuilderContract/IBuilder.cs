using DesignPatterns.ConsoleApp.CreationalPatterns.BuilderPattern.Product.SubProducts;

namespace DesignPatterns.ConsoleApp.CreationalPatterns.BuilderPattern.BuilderContract
{
    public interface IBuilder
    {
        void BuildItems(List<Item> items);
        void BuildDiscounts(List<Discount> discounts);
    }
}
