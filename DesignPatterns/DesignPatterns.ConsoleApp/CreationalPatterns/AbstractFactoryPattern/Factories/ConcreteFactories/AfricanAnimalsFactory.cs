using DesignPatterns.ConsoleApp.CreationalPatterns.AbstractFactoryContract.Factories.AbstractFactory;
using DesignPatterns.ConsoleApp.CreationalPatterns.AbstractFactoryPattern.Products.ConcreteProducts.AfricanProducts;
using DesignPatterns.ConsoleApp.CreationalPatterns.AbstractFactoryPattern.Products.ProductContract;

namespace DesignPatterns.ConsoleApp.CreationalPatterns.AbstractFactoryPattern.Factories.ConcreteFactories
{
    internal class AfricanAnimalsFactory : IAbstractFactory
    {
        public IHunter CreateHunter()
        {
            return new AfricanLion();
        }

        public IPrey CreatePrey()
        {
            return new AfricanGazelle();
        }
    }
}
