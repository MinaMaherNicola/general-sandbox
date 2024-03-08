using DesignPatterns.ConsoleApp.CreationalPatterns.AbstractFactoryPattern.Products.ProductContract;

namespace DesignPatterns.ConsoleApp.CreationalPatterns.AbstractFactoryPattern.Products.ConcreteProducts.AlaskanProducts
{
    internal class AlaskanWolf : IHunter
    {
        public void Hunt(IPrey prey)
        {
            Console.WriteLine($"Alaskan wolf hunting prey {typeof(IPrey)}");
            prey.Evade(this);
        }
    }
}
