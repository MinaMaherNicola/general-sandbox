using DesignPatterns.ConsoleApp.CreationalPatterns.AbstractFactoryPattern.Products.ProductContract;

namespace DesignPatterns.ConsoleApp.CreationalPatterns.AbstractFactoryPattern.Products.ConcreteProducts.AfricanProducts
{
    internal class AfricanLion : IHunter
    {
        public void Hunt(IPrey prey)
        {
            Console.WriteLine($"African lion Hunting prey {typeof(IPrey)}");
            prey.Evade(this);
        }
    }
}
