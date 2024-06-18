using DesignPatterns.ConsoleApp.CreationalPatterns.AbstractFactoryPattern.Products.ProductContract;

namespace DesignPatterns.ConsoleApp.CreationalPatterns.AbstractFactoryContract.Factories.AbstractFactory
{
    public interface IAbstractFactory
    {
        IHunter CreateHunter();
        IPrey CreatePrey();
    }
}
