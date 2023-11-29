using DesignPatterns.ConsoleApp.CreationalPatterns.FactoryMethod.Products.ProductContract;

namespace DesignPatterns.ConsoleApp.CreationalPatterns.FactoryMethod.Factories.FactoryContract
{
    public interface IPizzaFactory
    {
        IPizza BakePizza();
    }
}
