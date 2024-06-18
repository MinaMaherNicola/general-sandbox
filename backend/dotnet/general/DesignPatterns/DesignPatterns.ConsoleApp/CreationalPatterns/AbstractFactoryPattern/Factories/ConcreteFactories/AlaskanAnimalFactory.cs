using DesignPatterns.ConsoleApp.CreationalPatterns.AbstractFactoryContract.Factories.AbstractFactory;
using DesignPatterns.ConsoleApp.CreationalPatterns.AbstractFactoryPattern.Products.ConcreteProducts.AlaskanProducts;
using DesignPatterns.ConsoleApp.CreationalPatterns.AbstractFactoryPattern.Products.ProductContract;

namespace DesignPatterns.ConsoleApp.CreationalPatterns.AbstractFactoryPattern.Factories.ConcreteFactories
{
    internal class AlaskanAnimalFactory : IAbstractFactory
    {
        public IHunter CreateHunter()
        {
            return new AlaskanWolf();
        }

        public IPrey CreatePrey()
        {
            return new AlaskanRabbit();
        }
    }
}
