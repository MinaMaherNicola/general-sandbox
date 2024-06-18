using DesignPatterns.ConsoleApp.CreationalPatterns.AbstractFactoryPattern.Products.ProductContract;

namespace DesignPatterns.ConsoleApp.CreationalPatterns.AbstractFactoryPattern.Products.ConcreteProducts.AfricanProducts
{
    public class AfricanGazelle : IPrey
    {
        public void Evade(IHunter hunter)
        {
            Console.WriteLine($"African gazelle is evading hunter ${typeof(IHunter)}");
        }
    }
}
