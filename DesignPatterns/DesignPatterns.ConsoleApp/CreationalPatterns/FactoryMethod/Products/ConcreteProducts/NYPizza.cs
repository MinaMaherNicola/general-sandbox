using DesignPatterns.ConsoleApp.CreationalPatterns.FactoryMethod.Products.ProductContract;

namespace DesignPatterns.ConsoleApp.CreationalPatterns.FactoryMethod.Products.ConcreteProducts
{
    public class NYPizza : IPizza
    {
        public void EatPizza()
        {
            Console.WriteLine("Eating New York Pizza!");
        }
    }
}
