using DesignPatterns.ConsoleApp.CreationalPatterns.AbstractFactoryPattern.Products.ProductContract;

namespace DesignPatterns.ConsoleApp.CreationalPatterns.AbstractFactoryPattern.Products.ConcreteProducts.AlaskanProducts
{
    public class AlaskanRabbit : IPrey
    {
        public void Evade(IHunter hunter)
        {
            Console.WriteLine($"Alaskan rabbit is evading hunter ${typeof(IHunter)}");
        }
    }
}
